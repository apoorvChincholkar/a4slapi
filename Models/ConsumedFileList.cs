using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class ConsumedFileList
    {
        public short OrganizationId { get; set; }
        [StringLength(100)]
        public string FileName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [ForeignKey("OrganizationId")]
        [InverseProperty("ConsumedFileList")]
        public OrganizationMaster Organization { get; set; }
    }
}
