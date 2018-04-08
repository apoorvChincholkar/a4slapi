using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Utilities
    {
        public static string GetLastUpdatedOn(DateTime? lastUpdatedOnUTC, TimeZoneInfo timeZone)
        {
            if (!lastUpdatedOnUTC.HasValue)
            {
                return "N/A";
            }
            // Convert time to Local
            var localTime = System.TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

            // Get UTC Time
            var lastUpdatedOnLocal = System.TimeZoneInfo.ConvertTimeFromUtc(lastUpdatedOnUTC.Value, timeZone);

            if (localTime.Date == lastUpdatedOnLocal.Date)
            {
                return $"Today {lastUpdatedOnLocal.ToShortTimeString()}";
            }
            else
            {
                return lastUpdatedOnLocal.ToString("G");
            }
        }

        public static ValUnit ScaleCO2(double? value)
        {
            value = value.HasValue ? value.Value : 0;
            string unit = "";
            double result = 0;

            if ((value * 0.703) <= 1000)
            {
                result = Math.Round(value.Value * 0.703, 2, MidpointRounding.AwayFromZero);
                unit = "kg";
            }
            else
            {
                result = Math.Round(value.Value * 0.000703, 2, MidpointRounding.AwayFromZero);
                unit = "Metric Tons";
            }

            return new ValUnit(result, unit);
        }

        public static string ScaleCurrency(double? value)
        {
            value = value.HasValue ? value : 0;
            string unit = "";
            double result = 0;

            if (value <= 100000)
            {
                result = Math.Round(value.Value, 0, MidpointRounding.AwayFromZero);
            }
            else if (value <= 10000000)
            {
                result = Math.Round(value.Value / 100000, 2, MidpointRounding.AwayFromZero);
                unit = "L";
            }
            else
            {
                result = Math.Round(value.Value / 10000000, 2, MidpointRounding.AwayFromZero);
                unit = "Cr";
            }

            return result + unit;
        }

        public static ValUnit ScaleKW(double? value)
        {
            value = value.HasValue ? value : 0;

            if (value <= 1000)
            {
                return new ValUnit(Math.Round(value.Value, 2, MidpointRounding.AwayFromZero), "kW");
            }
            else if (value <= 1000000)
            {
                return new ValUnit(Math.Round(value.Value / 1000, 2, MidpointRounding.AwayFromZero), "MW");
            }
            else if (value <= 1000000000)
            {
                return new ValUnit(Math.Round(value.Value / 1000000, 2, MidpointRounding.AwayFromZero), "GW");
            }
            else
            {
                return new ValUnit(Math.Round(value.Value / 1000000000, 2, MidpointRounding.AwayFromZero), "TW");
            }
        }

        public static ValUnit ScaleKWh(double? value)
        {
            value = value.HasValue ? value : 0;

            if (value <= 1000)
            {
                return new ValUnit(Math.Round(value.Value, 2, MidpointRounding.AwayFromZero), "kWh");
            }
            else if (value <= 1000000)
            {
                return new ValUnit(Math.Round(value.Value / 1000, 2, MidpointRounding.AwayFromZero), "MWh");
            }
            else if (value <= 1000000000)
            {
                return new ValUnit(Math.Round(value.Value / 1000000, 2, MidpointRounding.AwayFromZero), "GWh");
            }
            else
            {
                return new ValUnit(Math.Round(value.Value / 1000000000, 2, MidpointRounding.AwayFromZero), "TWh");
            }
        }

        public static IEnumerable<ValUnit> ScaleKWh(IEnumerable<double> value)
        {
            double largest = value.Any() ? value.Max(x => x) : 0;

            if (largest <= 1000)
            {
                return value.Select(x => new ValUnit(Math.Round(x, 2, MidpointRounding.AwayFromZero), "kWh"));
            }
            else if (largest <= 1000000)
            {
                return value.Select(x => new ValUnit(Math.Round(x / 1000, 2, MidpointRounding.AwayFromZero), "MWh"));
            }
            else if (largest <= 1000000000)
            {
                return value.Select(x => new ValUnit(Math.Round(x / 1000000, 2, MidpointRounding.AwayFromZero), "GWh"));
            }
            else
            {
                return value.Select(x => new ValUnit(Math.Round(x / 1000000000, 2, MidpointRounding.AwayFromZero), "TWh"));
            }
        }

    }
}