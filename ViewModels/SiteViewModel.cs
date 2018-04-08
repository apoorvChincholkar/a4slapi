using System.Collections.Generic;
using Common;

namespace webapi.ViewModels
{
    public class InverterSummaryItem
    {
        public ValUnit Capacity { get; set; }
        public string Name { get; set; }
        public string NameMeter { get; set; } //energy meter
        public int Quantity { get; set; }
        public int QuantityMeter { get; set; } //energy meter
    }

    public class NotificationItem
    {
        public AlertType AlertType { get; set; }
        public string DateTime { get; set; }
        public string InverterName { get; set; }
        public string Message { get; set; }
    }

    public class SiteInverterRow
    {
        public ValUnit Capacity { get; set; }
        public ValUnit CUF { get; set; }
        public ValUnit CurrentPower { get; set; }
        public ValUnit CurrentPowerMeter { get; set; } //energy meter
        public ValUnit GenerationCurrentMonthMeter { get; set; }
        public ValUnit GenerationToday { get; set; }
        public ValUnit GenerationTodayMeter { get; set; } //energy meter

        //energy meter
        public int Id { get; set; }

        public int IdMeter { get; set; } //energy meter

        public string Name { get; set; }
        public string NameMeter { get; set; } //energy meter
        public InverterStatus Status { get; internal set; }
        public string StatusDescription { get; internal set; }
        public string StatusDescriptionMeter { get; internal set; }
        public InverterStatus StatusMeter { get; internal set; } //energy meter

        //energy meter
        public string StatusUpdatedOn { get; internal set; }

        public string StatusUpdatedOnMeter { get; internal set; } //energy meter
        public NotificationItem Warning { get; set; }
    }

    public class SiteViewModel
    {
        public ValUnit AverageCUF { get; set; }
        public KeyValuePair<string, string> BillAmount { get; set; }
        public List<YieldChartDataItem> ChartData { get; set; }
        public List<YieldChartDataItem> ChartDataMeter { get; set; } //energy meter
        public ValUnit CO2Saved { get; set; }
        public ValUnit CurrentPower { get; set; }
        public ValUnit CurrentPowerMeter { get; set; } //energy meter
        public ValUnit DcCapacity { get; set; }
        public ValUnit DcCapacityMeter { get; set; } //energy meter
        public KeyValuePair<string, string> Earnings { get; set; }

        //energy meter
        public List<SiteInverterRow> EnergyMeterList { get; set; }  //energy meter

        public List<InverterSummaryItem> EnergyMeterSummary { get; set; } //energy meter
        public ValUnit GenerationCurrentMonth { get; set; }
        public ValUnit GenerationCurrentMonthMeter { get; set; } //energy meter
        public ValUnit GenerationToday { get; set; }
        public ValUnit GenerationTodayMeter { get; set; } //energy meter
        public int Id { get; set; }
        public int IdMeter { get; set; } //energy meter
        public List<SiteInverterRow> InverterList { get; set; }

        public List<InverterSummaryItem> InverterSummary { get; set; }

        public string LastUpdatedOn { get; set; }

        public string LastUpdatedOnMeter { get; set; } //energy Meter
        public double? Latitude { get; set; }
        public double? LatitudeMeter { get; set; } //energy meter
        public ValUnit LifetimeGeneration { get; set; }
        public ValUnit LifetimeGenerationMeter { get; set; } //energy meter
        public double? Longitude { get; set; }
        public double? LongitudeMeter { get; set; } //energy meter
        public string Name { get; set; }
        public string NameMeter { get; set; } //energy meter
        public ValUnit PowerFactor { get; set; } //energy meter
        public ValUnitPercentage SpecificYield { get; set; }

        //energy meter
        public List<NotificationItem> Warnings { get; set; }

        public DashboardChartModel YieldChartData { get; set; }
        public DashboardChartModel YieldChartDataMeter { get; set; } //energy meter
    }

    public class WeatherItem
    {
        public double? Cloud { get; set; } //for solar automation only
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Place { get; set; }
        public double? Rain { get; set; }
        public double Temperature { get; set; }
        public double Wind { get; set; }
    }

    public class YieldChartDataItem
    {
        public double? CurrentYield { get; set; }
        public double? CurrentYieldMeter { get; set; } //energy meter
        public double? EstimatedYield { get; set; }
        public double? EstimatedYieldMeter { get; set; } //energy meter
        public string Label { get; set; }
        public string LabelMeter { get; set; } //energy meter
    }
}