using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.ViewModel
{
    public class ModelForCreate
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="nhập một định dạng của email")]
        public string Email { get; set; }

        public string PhoneNum { get; set; }

        public IFormFile iformfile_path { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Not Match Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Province { get; set; }

        [Required]
        public int District { get; set; }

        [Required]
        public int Ward { get; set; }

        [Required]
        public string HouseNumber { get; set; }
    }
}
