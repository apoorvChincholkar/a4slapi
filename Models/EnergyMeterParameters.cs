using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class EnergyMeterParameters
    {
        public short OrganizationId { get; set; }
        public short SiteId { get; set; }
        public short MeterId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        [StringLength(50)]
        public string ParameterName { get; set; }
        public short Type { get; set; }
        public double Value { get; set; }
        [Required]
        [StringLength(10)]
        public string Unit { get; set; }
    }
}
