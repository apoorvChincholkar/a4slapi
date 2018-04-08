using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class OrganizationMaster
    {
        public OrganizationMaster()
        {
            ConsumedFileList = new HashSet<ConsumedFileList>();
            DailyReportDispatchRecord = new HashSet<DailyReportDispatchRecord>();
            DailyReportMailingList = new HashSet<DailyReportMailingList>();
            InverterData = new HashSet<InverterData>();
            SiteMaster = new HashSet<SiteMaster>();
            SubscriptionMaster = new HashSet<SubscriptionMaster>();
            TicketMaster = new HashSet<TicketMaster>();
            TimelineData = new HashSet<TimelineData>();
            UserMaster = new HashSet<UserMaster>();
        }

        public short Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string Timezone { get; set; }
        [Required]
        [StringLength(50)]
        public string CurrencyName { get; set; }
        [Required]
        [StringLength(5)]
        public string CurrencySymbol { get; set; }
        public double? TotalCapacity { get; set; }
        [StringLength(20)]
        public string SubscriptionPlan { get; set; }
        public short? Status { get; set; }

        [ForeignKey("Timezone")]
        [InverseProperty("OrganizationMaster")]
        public TimezoneMaster TimezoneNavigation { get; set; }
        [InverseProperty("Organization")]
        public ICollection<ConsumedFileList> ConsumedFileList { get; set; }
        [InverseProperty("Organization")]
        public ICollection<DailyReportDispatchRecord> DailyReportDispatchRecord { get; set; }
        [InverseProperty("Organization")]
        public ICollection<DailyReportMailingList> DailyReportMailingList { get; set; }
        [InverseProperty("Organization")]
        public ICollection<InverterData> InverterData { get; set; }
        [InverseProperty("Organization")]
        public ICollection<SiteMaster> SiteMaster { get; set; }
        [InverseProperty("Organization")]
        public ICollection<SubscriptionMaster> SubscriptionMaster { get; set; }
        [InverseProperty("Organization")]
        public ICollection<TicketMaster> TicketMaster { get; set; }
        [InverseProperty("Organization")]
        public ICollection<TimelineData> TimelineData { get; set; }
        [InverseProperty("Organization")]
        public ICollection<UserMaster> UserMaster { get; set; }
    }
}
