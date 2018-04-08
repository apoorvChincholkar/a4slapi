using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class TicketMaster
    {
        public TicketMaster()
        {
            TicketHistory = new HashSet<TicketHistory>();
        }

        public short OrganizationId { get; set; }
        public int Id { get; set; }
        public short Status { get; set; }
        public int? AssignedToUser { get; set; }
        public int CreatedByUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public short? SiteId { get; set; }
        public short? InverterId { get; set; }
        public int? AlertId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdatedOn { get; set; }

        [ForeignKey("OrganizationId")]
        [InverseProperty("TicketMaster")]
        public OrganizationMaster Organization { get; set; }
        [InverseProperty("TicketMaster")]
        public ICollection<TicketHistory> TicketHistory { get; set; }
    }
}
