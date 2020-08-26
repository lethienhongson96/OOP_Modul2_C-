using System;
using System.Collections.Generic;

namespace PharmacyWeb.Models
{
    public partial class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public int? ProvinceId { get; set; }
    }
}
