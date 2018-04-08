using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class AlertData
    {
        public short OrganizationId { get; set; }
        public short SiteId { get; set; }
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        public short AlertLevel { get; set; }
        public short? InverterId { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool TicketCreated { get; set; }

        [ForeignKey("OrganizationId,SiteId")]
        [InverseProperty("AlertData")]
        public SiteMaster SiteMaster { get; set; }
    }
}
