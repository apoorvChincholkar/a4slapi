using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class CleaningAgencyTicketDetails
    {
        public short Id { get; set; }
        public short OrganizationId { get; set; }
        public short SiteId { get; set; }
        public short AgencyId { get; set; }
        [Required]
        [StringLength(250)]
        public string MailBody { get; set; }
        public short Status { get; set; }
        public int CreatedByUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
    }
}
