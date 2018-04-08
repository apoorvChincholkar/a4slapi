using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class SiteMaster
    {
        public SiteMaster()
        {
            AlertData = new HashSet<AlertData>();
            HourlySiteEstimate = new HashSet<HourlySiteEstimate>();
            InverterData = new HashSet<InverterData>();
            InverterMaster = new HashSet<InverterMaster>();
        }

        public short OrganizationId { get; set; }
        public short Id { get; set; }
        public Guid SubscriptionId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Address { get; set; }
        public short Status { get; set; }
        public short? TechnicianId { get; set; }
        public double? Lattitude { get; set; }
        public double? Longitude { get; set; }
        public double? TotalCapacity { get; set; }
        public double? CurrentPower { get; set; }
        public double? LifetimeYield { get; set; }
        public double? TodaysYield { get; set; }
        public double? YesterdaysYield { get; set; }
        public double? Last7DaysYield { get; set; }
        public double? Last30DaysYield { get; set; }
        public double? CurrentMonthYield { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdatedOn { get; set; }
        public double EnergyUnitRate { get; set; }

        [ForeignKey("OrganizationId")]
        [InverseProperty("SiteMaster")]
        public OrganizationMaster Organization { get; set; }
        [ForeignKey("OrganizationId,SubscriptionId")]
        [InverseProperty("SiteMaster")]
        public SubscriptionMaster SubscriptionMaster { get; set; }
        [InverseProperty("SiteMaster")]
        public ICollection<AlertData> AlertData { get; set; }
        [InverseProperty("SiteMaster")]
        public ICollection<HourlySiteEstimate> HourlySiteEstimate { get; set; }
        [InverseProperty("SiteMaster")]
        public ICollection<InverterData> InverterData { get; set; }
        [InverseProperty("SiteMaster")]
        public ICollection<InverterMaster> InverterMaster { get; set; }
    }
}
