using System.Collections.Generic;

namespace webapi.ViewModels
{
    public class DashboardChartModel
    {
        public List<string> DateLabels { get; set; }
        public List<string> DateLabelsMeter { get; set; }
        public List<double> Values { get; set; }
        public List<double> ValuesMeter { get; set; }
        public string YAxisLabel { get; set; }
        public string YAxisLabelMeter { get; set; }
    }
}