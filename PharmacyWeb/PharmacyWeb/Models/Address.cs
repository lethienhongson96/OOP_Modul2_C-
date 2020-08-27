using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.Models
{
    public class Address
    {
        [Key]
        public int Address_Id{ get; set; }
        public int Province { get; set; }
        public int District { get; set; }
        public int Ward { get; set; }
        public string HouseNum { get; set; }
        
        public ApplicationUser ApplicationUser{ get; set; }
    }
}
