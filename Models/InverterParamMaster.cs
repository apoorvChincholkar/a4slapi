using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class InverterParamMaster
    {
        public short OrganizationId { get; set; }
        public short Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ParamName { get; set; }
        [StringLength(50)]
        public string Unit { get; set; }
    }
}
