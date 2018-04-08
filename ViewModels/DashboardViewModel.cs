using System.Collections.Generic;
using Common;

namespace webapi.ViewModels
{
    public class DashboardViewModel
    {
        public ValUnit AverageCUF { get; set; }
        public ValUnit AveragePR { get; set; }
        public KeyValuePair<string, string> BillingAmount { get; set; } //energy Meter
        public DashboardChartModel ChartData { get; set; }
        public DashboardChartModel ChartDataMeter { get; set; } //energy meter
        public ValUnit CO2Saved { get; set; }
        public ValUnitPercentage CurrentPower { get; set; }
        public ValUnitPercentage CurrentPowerMeter { get; set; } //energy meter
        public KeyValuePair<string, string> Earnings { get; set; }
        public List<KeyValuePair<short, string>> EnergyMeterList { get; set; } //for energy meter
        public ValUnit GenerationToday { get; set; }
        public ValUnit GenerationTodayMeter { get; set; } //energy meter
        public string LastUpdatedOn { get; internal set; }
        public string LastUpdatedOnMeter { get; internal set; } //energy Meter
        public ValUnit LifetimeGeneration { get; set; }
        public ValUnit LifetimeGenerationMeter { get; set; } //energy Meter
        public int MeterCount { get; set; } //energy meter
        public ValUnit PowerFactor { get; set; } //energy meter
        public int SiteCount { get; set; }
        public List<KeyValuePair<short, string>> SiteList { get; set; }
        public List<SiteWidgetViewModel> SiteWidgetList { get; set; }
        public ValUnitPercentage SpecificYield { get; set; }
        public ValUnit TotalCapacity { get; set; }
    }
}