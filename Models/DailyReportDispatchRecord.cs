using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class DailyReportDispatchRecord
    {
        public short OrganizationId { get; set; }
        [StringLength(250)]
        public string EmailId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [ForeignKey("OrganizationId")]
        [InverseProperty("DailyReportDispatchRecord")]
        public OrganizationMaster Organization { get; set; }
    }
}
