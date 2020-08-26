using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWebApplication.Models
{
    public class Address
    {
        [Key]
        public int Address_Id { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string HouseNumber { get; set; }

        public int User_Id { get; set; }
        public User User{ get; set; }
    }
}
