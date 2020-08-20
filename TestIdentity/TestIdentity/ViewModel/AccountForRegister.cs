using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestIdentity.ViewModel
{
    public class AccountForRegister
    {

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Required]
        public string PhoneNum { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string PassWord { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("PassWord",ErrorMessage ="Not Match Password")]
        public string ConfirmPassWord { get; set; }

        public string User_Role { get; set; }
    }
}
