using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using Newtonsoft.Json;
using webapi.ViewModels;
using Common;
using System.Globalization;

namespace webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        public HomeController(webapiDbContext context)
        {
            _context = context;
        }

        private webapiDbContext _context;

        [HttpGet]
        public JsonResult GetDashboardData()
        {
            DashboardViewModel result = new DashboardViewModel();
            int organizationId = 1;

            var localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            DateTime localDate = localTime.Date;
            DateTime MonthStart = new DateTime(localDate.Year, localDate.Month, 1);
            DateTime weekStart = localDate.AddDays(-7);

            try
            {
                // Get organization
                var organization = _context.OrganizationMaster
                   .Include("SiteMaster")
                   .First(x => x.Id == organizationId);

                var sites = organization.SiteMaster
                .Where(x => x.Status == (short)SiteStatus.Active)
                .ToList();

                var siteIds = sites.Select(x => x.Id).ToArray();

                // Get corresponding inverter list
                var inverters = _context.InverterMaster
                .Where(x => x.OrganizationId == organizationId && siteIds.Contains(x.SiteId))
                .AsNoTracking()
                .ToList();

                // Get Total Inverter Capacity
                var totalCapacity = sites.Any() ? sites.Sum(x => x.TotalCapacity.HasValue ? x.TotalCapacity.Value : 0) : 0;
                result.TotalCapacity = Utilities.ScaleKW(totalCapacity);

                // Get Lifetime Yield
                result.LifetimeGeneration = Utilities.ScaleKWh(sites.Sum(x => x.LifetimeYield.HasValue ? x.LifetimeYield.Value : 0));

                // Get Site Count
                result.SiteCount = sites.Count;

                // Get Site List
                result.SiteList = sites.Select(x => new KeyValuePair<short, string>(x.Id, x.Name))
                    .OrderBy(x => x.Value)
                    .ToList();

                // Get Earnings This Month
                result.Earnings = new KeyValuePair<string, string>(Utilities.ScaleCurrency(sites.Sum(x => x.CurrentMonthYield.HasValue ? x.CurrentMonthYield.Value * x.EnergyUnitRate : 0)), "Rs");

                // Get CO2 Saved Today
                var generationToday = sites.Sum(x => x.TodaysYield.HasValue ? x.TodaysYield.Value : 0);
                result.CO2Saved = Utilities.ScaleCO2(generationToday);

                List<AlertData> recentAlerts = _context.AlertData
                .Where(x => x.OrganizationId == organizationId && x.IsActive && x.DateTime >= weekStart)
                .AsNoTracking()
                .ToList();

                // Get Site Widget List
                result.SiteWidgetList = sites
                    .OrderByDescending(x => recentAlerts.Any(y => y.SiteId == x.Id))
                    .ThenByDescending(x => recentAlerts.Any() ? recentAlerts.Max(y => y.AlertLevel) : 0)
                    .ThenByDescending(x => x.CurrentPower)
                    .Take(4)
                    .Select(x => new
                    {
                        site = x,
                        latestAlert = recentAlerts.Any(y => y.SiteId == x.Id) ? recentAlerts.Where(y => y.SiteId == x.Id).Last() : null,
                        capacity = x.TotalCapacity.HasValue ? x.TotalCapacity.Value : 0,
                        currentPower = x.CurrentPower.HasValue ? x.CurrentPower.Value : 0
                    })
                    .Select(x => new SiteWidgetViewModel()
                    {
                        Name = x.site.Name,
                        CurrentPower = Utilities.ScaleKW(x.currentPower),
                        Capacity = Utilities.ScaleKW(x.capacity),
                        GenerationPercentage = x.capacity == 0 ? 0 : (x.currentPower / x.capacity) * 100,
                        Alert = x.latestAlert != null ? new NotificationItem()
                        {
                            AlertType = (AlertType)recentAlerts.Where(y => y.SiteId == x.site.Id).Max(y => y.AlertLevel),
                            DateTime = x.latestAlert.DateTime.ToShortDateString(),
                            InverterName = x.latestAlert.InverterId.HasValue ? inverters.First(y => y.Id == x.latestAlert.InverterId.Value).Name : string.Empty,
                            Message = x.latestAlert.Description
                        } : null
                    }).ToList();

                // Calculate Current Power
                var currentPower = sites.Sum(x => x.CurrentPower.HasValue ? x.CurrentPower.Value : 0);
                var scaledCurrentPower = Utilities.ScaleKW(currentPower);

                result.CurrentPower = new ValUnitPercentage(scaledCurrentPower.Val, totalCapacity == 0 ? 0 : (currentPower / totalCapacity) * 100, scaledCurrentPower.Unit);

                // Calculate Generation Today
                result.GenerationToday = Utilities.ScaleKWh(generationToday);

                // Calculate CUF
                var generationPast7Days = sites.Sum(x => x.Last7DaysYield.HasValue ? x.Last7DaysYield.Value : 0);
                var fullGenerationPast7Days = (6 * 24 + localTime.Hour) * totalCapacity;
                result.AverageCUF = new ValUnit(fullGenerationPast7Days > 0 ? Math.Round((generationPast7Days / fullGenerationPast7Days) * 100, 2, MidpointRounding.AwayFromZero) : 0, "%");

                // Calculate PR
                result.AveragePR = new ValUnit(generationPast7Days == 0 ? 0 : 0, "%");

                // Calculate Specific Yield
                result.SpecificYield = new ValUnitPercentage(totalCapacity == 0 ? 0 : Math.Round(generationPast7Days / totalCapacity, 2, MidpointRounding.AwayFromZero), generationPast7Days == 0 ? 0 : 100, "kWh/kWp");

                short[] siteIdList = sites.Select(x => x.Id).ToArray();

                //  Calculate Chart Data
                var generationData = _context.InverterData
                    .AsNoTracking()
                    .Where(x => x.OrganizationId == organization.Id && x.DateTime >= weekStart && x.TotalEnergy > 0)
                    .Select(x => new { x.SiteId, x.InverterId, x.TotalEnergy, x.DateTime })
                    .ToList()
                    .Select(x => new { x.SiteId, x.InverterId, x.TotalEnergy, DateTime = TimeZoneInfo.ConvertTimeFromUtc(x.DateTime, localTimeZone) })
                    .GroupBy(x => new { x.SiteId, x.InverterId, Dt = x.DateTime.Month + " " + x.DateTime.Day })
                    .Where(x => x.Count() > 1)
                    .Select(x => x.OrderByDescending(y => y.DateTime))
                    .Select(x => new { date = x.First().DateTime.Date, val = x.First().TotalEnergy - x.Last().TotalEnergy })
                    .ToList();

                var dateContainer = (new List<int>() { 6, 5, 4, 3, 2, 1, 0 }).Select(x => DateTime.Now.Date.AddDays(-x)).ToList();

                var scaledVals = Utilities.ScaleKWh(dateContainer.Select(x => generationData.Any(y => y.date == x.Date) ? generationData.Where(y => y.date == x.Date).Sum(y => y.val.HasValue ? y.val.Value : 0) : 0));

                result.ChartData = new DashboardChartModel()
                {
                    DateLabels = dateContainer.Select(x => x.ToString("MMM d", CultureInfo.InvariantCulture)).ToList(),
                    Values = scaledVals.Select(x => x.Val).ToList(),
                    YAxisLabel = "Yield (" + scaledVals.First().Unit + ")"
                };

                // Set Last Updated Date
                var lastUpdated = sites.Max(x => x.LastUpdatedOn);
                result.LastUpdatedOn = Utilities.GetLastUpdatedOn(lastUpdated, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = ex.Message });
                //logger.Error(ex, "Exception Occurred");
            }

            return new JsonResult(result);
        }

    }
}
