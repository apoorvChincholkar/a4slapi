using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class DailyReportMailingList
    {
        public short OrganizationId { get; set; }
        public int Id { get; set; }
        [StringLength(250)]
        public string EmailId { get; set; }
        [StringLength(30)]
        public string MobileNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedOn { get; set; }

        [ForeignKey("OrganizationId")]
        [InverseProperty("DailyReportMailingList")]
        public OrganizationMaster Organization { get; set; }
    }
}
