using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestIdentity.Models;
using TestIdentity.ViewModel;

namespace TestIdentity.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View(await _userManager.Users.ToListAsync());

        [HttpGet]
        public IActionResult Edit(string id) => View(_userManager.FindByIdAsync(id).Result);

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser User, string Role_Id)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser identityUser = Mapping(User);

                var role = await _roleManager.FindByIdAsync(Role_Id);
                var roles = _userManager.GetRolesAsync(User).Result;

                var result = await _userManager.UpdateAsync(identityUser);

                if (result.Succeeded)
                {
                    await _userManager.RemoveFromRolesAsync(identityUser, roles);
                    await _userManager.AddToRoleAsync(identityUser, role.Name);

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(User);
        }

        public ApplicationUser Mapping(ApplicationUser user)
        {
            var FindUser = _userManager.FindByIdAsync(user.Id).Result;

            FindUser.Email = user.Email;
            FindUser.UserName = user.Email;
            FindUser.PhoneNumber = user.PhoneNumber;
            FindUser.Address = user.Address;
            FindUser.FullName = user.FullName;

            return FindUser;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = _userManager.FindByIdAsync(id).Result;
                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AccountForCreate user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser identityUser = new ApplicationUser()
                {
                    UserName = user.Email,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNum,
                    FullName = user.FullName,
                    Address = user.Address
                };
                var FindResult = _userManager.FindByEmailAsync(user.Email).Result;

                if (FindResult != null)
                {
                    ModelState.AddModelError("", "exist this email !");
                    return View(user);
                }
                var result = await _userManager.CreateAsync(identityUser, user.Password);

                if (result.Succeeded)
                {
                    var role = _roleManager.FindByIdAsync(user.Role_Id);
                    await _userManager.AddToRoleAsync(identityUser, role.Result.Name);

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(user);
        }
    }
}
