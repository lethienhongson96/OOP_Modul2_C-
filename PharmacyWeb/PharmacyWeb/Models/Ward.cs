using System;
using System.Collections.Generic;

namespace PharmacyWeb.Models
{
    public partial class Ward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
    }
}
