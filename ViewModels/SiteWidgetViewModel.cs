using Common;

namespace webapi.ViewModels
{
    public class SiteWidgetViewModel
    {
        public SiteWidgetViewModel()
        {
        }

        public NotificationItem Alert { get; set; }
        public ValUnit Capacity { get; set; }
        public ValUnit CurrentPower { get; set; }
        public double GenerationPercentage { get; set; }
        public string Name { get; internal set; }
    }
}