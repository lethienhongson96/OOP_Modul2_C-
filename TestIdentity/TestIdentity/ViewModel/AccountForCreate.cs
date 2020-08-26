using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestIdentity.ViewModel
{
    public class AccountForCreate
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("Password", ErrorMessage = "Not Match Password")]
        public string ConfirmPassWord { get; set; }

        [Required]
        public string FullName { get; set; }

        [Phone]
        public string PhoneNum { get; set; }

        public string Address { get; set; }

        public string Role_Id { get; set; }
    }
}
