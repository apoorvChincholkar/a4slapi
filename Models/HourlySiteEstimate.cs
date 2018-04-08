using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class HourlySiteEstimate
    {
        public short OrganizationId { get; set; }
        public short SiteId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        public double EstimatedPower { get; set; }

        [ForeignKey("OrganizationId,SiteId")]
        [InverseProperty("HourlySiteEstimate")]
        public SiteMaster SiteMaster { get; set; }
    }
}
