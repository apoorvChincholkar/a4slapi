using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class CleaningMaster
    {
        public short Id { get; set; }
        [StringLength(100)]
        public string AgencyName { get; set; }
        [StringLength(100)]
        public string AgencyPersonName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(20)]
        public string ContactNumber { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        public short? AgencyId { get; set; }
    }
}
