using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestIdentity.ViewModel;

namespace TestIdentity.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Addrole(string rolename)
        {
            if (rolename != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(rolename.Trim()));
            }

            return RedirectToAction("Index", "Role");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var identityRole = _roleManager.Roles.FirstOrDefault(r => r.Id == id);
            Role role = new Role()
            {
                Role_Name = identityRole.Name,
                Role_Id = identityRole.Id
            };

            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                var identityRole = await _roleManager.FindByIdAsync(role.Role_Id);
                identityRole.Name = role.Role_Name;

                await _roleManager.UpdateAsync(identityRole);
                return RedirectToAction("Index", "Role");
            }

            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Role");
                    }
                }
            }
            return RedirectToAction("Index", "Role");
        }
    }
}
