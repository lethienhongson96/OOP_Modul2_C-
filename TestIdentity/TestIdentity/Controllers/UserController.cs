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
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Users = await _userManager.Users.ToListAsync();

            return View(Users);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var User = _userManager.FindByIdAsync(id).Result;

            return View(User);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityUser User)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = _userManager.FindByIdAsync(User.Id).Result;
                identityUser.Email = User.Email;
                identityUser.UserName = User.Email;
                identityUser.PhoneNumber = User.PhoneNumber;

                var result = await _userManager.UpdateAsync(identityUser);

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

            return View(User);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = _userManager.FindByIdAsync(id).Result;
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
                            ModelState.AddModelError("",item.Description);
                        }
                    }
                }
            }

            return RedirectToAction("Index","User");
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AccountForRegister user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser()
                {
                    UserName = user.Email,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNum
                };
                var FindResult = _userManager.FindByEmailAsync(user.Email).Result;

                if (FindResult != null)
                {
                    ModelState.AddModelError("", "exist this email !");
                    return View(user);
                }
                var result = await _userManager.CreateAsync(identityUser,user.PassWord);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index","User");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }            

            return View(user);
        }
    }
}
