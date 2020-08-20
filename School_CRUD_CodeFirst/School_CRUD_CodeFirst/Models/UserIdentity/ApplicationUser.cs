using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_CRUD_CodeFirst.Models.UserIdentity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
