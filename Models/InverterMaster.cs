using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class InverterMaster
    {
        public InverterMaster()
        {
            InverterData = new HashSet<InverterData>();
        }

        public short OrganizationId { get; set; }
        public short SiteId { get; set; }
        public short Id { get; set; }
        public int? Type { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string DisplayName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InstallationDate { get; set; }
        public double Capacity { get; set; }
        public double? CurrentPower { get; set; }
        public double? LifetimeYield { get; set; }
        public double? TodaysYield { get; set; }
        public double? YesterdaysYield { get; set; }
        public double? Last7DaysYield { get; set; }
        public double? Last30DaysYield { get; set; }
        public double? CurrentMonthYield { get; set; }

        [ForeignKey("OrganizationId,SiteId")]
        [InverseProperty("InverterMaster")]
        public SiteMaster SiteMaster { get; set; }
        [InverseProperty("InverterMaster")]
        public ICollection<InverterData> InverterData { get; set; }
    }
}
