using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyWeb.Models;
using PharmacyWeb.ViewModel;

namespace PharmacyWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly PharmacyWebDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(PharmacyWebDbContext context, IWebHostEnvironment hostEnvironment,
            UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this._context = context;
            this._hostEnvironment = hostEnvironment;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index(ApplicationUser user)
        {
            return View(user);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ModelForCreate model)
        {

            if (ModelState.IsValid)
            {
                Address address = new Address()
                {
                    Province = _context.Province.ToList().Find(el => el.Id == model.Province).Name,
                    District = _context.District.ToList().Find(el => el.Id == model.District).Name,
                    Ward = _context.Ward.ToList().Find(el => el.Id == model.Ward).Name,
                    HouseNum = model.HouseNumber
                };
                _context.Add(address);
                await _context.SaveChangesAsync();

                ApplicationUser User = new ApplicationUser()
                {
                    Avatar_Path = UploadedFile(model),
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNum,
                    Email = model.Email,
                    UserName = model.Email,
                    Address = address
                };

                var result = await _userManager.CreateAsync(User, model.Password);


                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(User, false);
                    return RedirectToAction("Index", "Account",User);
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid account or password");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



        public JsonResult GetDistrictById(int id)
        {
            var list = _context.District.Where(x => x.ProvinceId == id).ToList();
            return Json(new SelectList(list, "Id", "Name"));
        }

        public JsonResult GetWardById(int id)
        {
            var list = _context.Ward.Where(x => x.DistrictId == id).ToList();
            return Json(new SelectList(list, "Id", "Name"));
        }

        private string UploadedFile(ModelForCreate model)
        {
            string uniqueFileName = null;

            if (model.iformfile_path != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.iformfile_path.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.iformfile_path.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
