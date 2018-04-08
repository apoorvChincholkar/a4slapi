using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class TicketHistory
    {
        public short OrganizationId { get; set; }
        public int Id { get; set; }
        public int TicketId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        public int ChangedByUser { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }

        [ForeignKey("OrganizationId,TicketId")]
        [InverseProperty("TicketHistory")]
        public TicketMaster TicketMaster { get; set; }
    }
}
