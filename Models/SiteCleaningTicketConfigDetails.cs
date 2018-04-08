using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class SiteCleaningTicketConfigDetails
    {
        public short Id { get; set; }
        public short OrganizationId { get; set; }
        public short SiteId { get; set; }
        public short? AgencyId { get; set; }
        public bool? IsrRecursive { get; set; }
        public int? CleaningDuration { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastGeneratedDate { get; set; }
    }
}
