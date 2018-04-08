using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("__MigrationHistory")]
    public partial class MigrationHistory
    {
        [StringLength(150)]
        public string MigrationId { get; set; }
        [StringLength(300)]
        public string ContextKey { get; set; }
        [Required]
        public byte[] Model { get; set; }
        [Required]
        [StringLength(32)]
        public string ProductVersion { get; set; }
    }
}
