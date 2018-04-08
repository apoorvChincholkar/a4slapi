using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class TimelineData
    {
        public short OrganizationId { get; set; }
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        public short Type { get; set; }
        public short? SiteId { get; set; }
        public short? InverterId { get; set; }
        public int? TicketId { get; set; }
        public short? UserId { get; set; }
        public int? AlertId { get; set; }
        [Required]
        public string Description { get; set; }

        [ForeignKey("OrganizationId")]
        [InverseProperty("TimelineData")]
        public OrganizationMaster Organization { get; set; }
    }
}
