using Microsoft.AspNetCore.Http;
using PharmacyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWebApplication.ViewModel
{
    public class ModelForCreate 
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public IFormFile iformfile_path{ get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int Province { get; set; }
        public int District { get; set; }
        public int Ward { get; set; }
        public string HouseNumber { get; set; }
    }
}
