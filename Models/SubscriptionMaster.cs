using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class SubscriptionMaster
    {
        public SubscriptionMaster()
        {
            SiteMaster = new HashSet<SiteMaster>();
        }

        public short OrganizationId { get; set; }
        public Guid SubscriptionId { get; set; }
        public short SubscriptionType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PurchasedDate { get; set; }
        [StringLength(2500)]
        public string Comments { get; set; }

        [ForeignKey("OrganizationId")]
        [InverseProperty("SubscriptionMaster")]
        public OrganizationMaster Organization { get; set; }
        [InverseProperty("SubscriptionMaster")]
        public ICollection<SiteMaster> SiteMaster { get; set; }
    }
}
