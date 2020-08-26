using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        
        public string Avatar_Path { get; set; }

        public Address Address{ get; set; }
        public int Address_Id{ get; set; }
    }
}
