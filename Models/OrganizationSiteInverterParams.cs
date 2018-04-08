using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class OrganizationSiteInverterParams
    {
        public int Id { get; set; }
        public short OrganizationId { get; set; }
        public short SiteId { get; set; }
        public short ParamId { get; set; }
    }
}
