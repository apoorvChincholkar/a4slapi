using System.ComponentModel;

namespace Common
{
    public enum AlertType
    {
        Information = 1,
        Warning,
        Faults
    }

    public enum InverterStatus
    {
        [Description("Idle:Initializing")]
        IdleInitializing = 0,

        [Description("Idle:ISO Detecting")]
        IdleISODetecting = 1,

        [Description("Idle:Irradiation Detecting")]
        IdleIrradiationDetecting = 2,

        [Description("Starting")]
        Starting = 256,

        [Description("On-grid")]
        OnGrid = 512,

        [Description("On-grid:Limited")]
        OnGridLimited = 513,

        [Description("Shutdown:Abnormal")]
        ShutdownAbnormal = 768,

        [Description("Shutdown:Forced")]
        ShutdownForced = 769,

        [Description("Grid Dispatched:cos?-P Curve")]
        GridDispatchcosPCurve = 1025,

        [Description("Grid Dispatch:Q-U Curve")]
        GridDispatchQUCurve = 1026,

        [Description("Idle:No Irradiation")]
        IdleNoIrradiation = 40960,
    }

    public enum ParameterType
    {
        NotApplicable = 0,
        Min,
        Max,
        Avg
    }

    public enum SiteStatus
    {
        Active = 1,
        Inactive,
        Expired
    }

    public enum SupportTicketPriority
    {
        [Description("High")]
        High = 1,

        [Description("Medium")]
        Medium,

        [Description("Low")]
        Low,

        [Description("Improvement")]
        Improvement
    }

    public enum SupportTicketStatus
    {
        [Description("Created")]
        Created = 1,

        [Description("Assigned")]
        Assigned,

        [Description("In Progress")]
        InProgress,

        [Description("Closed")]
        Closed,

        [Description("Deleted")]
        Deleted
    }

    public enum TicketStatus
    {
        [Description("Created")]
        Created = 1,

        [Description("Assigned")]
        Assigned,

        [Description("In Progress")]
        InProgress,

        [Description("Closed")]
        Closed,

        [Description("Deleted")]
        Deleted
    }

    public enum TimelineItemType
    {
        Day = 1,
        Warning,
        Fault,
        Addition,
        Report,
        Information
    }

    public enum TimePeriod
    {
        Day = 1,
        Week,
        Month,
        Quarter,
        Year
    }

    public class ValUnit
    {
        public ValUnit(double val, string unit)
        {
            Val = val;
            Unit = unit;
        }

        public string Unit { get; set; }
        public double Val { get; set; }
    }

    public class ValUnitPercentage
    {
        public ValUnitPercentage(double val, double percent, string unit)
        {
            Val = val;
            Unit = unit;
            Percent = percent;
        }

        public double Percent { get; set; }
        public string Unit { get; set; }
        public double Val { get; set; }
    }
}