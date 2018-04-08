using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class TimezoneMaster
    {
        public TimezoneMaster()
        {
            OrganizationMaster = new HashSet<OrganizationMaster>();
        }

        [StringLength(150)]
        public string Id { get; set; }
        [Required]
        [StringLength(150)]
        public string StandardName { get; set; }
        [Required]
        [StringLength(200)]
        public string DisplayName { get; set; }
        public long BaseUtcOffset { get; set; }

        [InverseProperty("TimezoneNavigation")]
        public ICollection<OrganizationMaster> OrganizationMaster { get; set; }
    }
}
