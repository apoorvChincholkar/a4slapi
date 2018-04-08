using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class UserMaster
    {
        public short OrganizationId { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        public short? CountryCode { get; set; }
        [StringLength(20)]
        public string ContactNumber { get; set; }

        [ForeignKey("OrganizationId")]
        [InverseProperty("UserMaster")]
        public OrganizationMaster Organization { get; set; }
    }
}
