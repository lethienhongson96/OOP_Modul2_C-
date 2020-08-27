using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PharmacyWeb.Models;
using PharmacyWeb.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly PharmacyWebDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(PharmacyWebDbContext context, IWebHostEnvironment hostEnvironment,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._context = context;
            this._hostEnvironment = hostEnvironment;
            this._userManager = userManager;
            this._signInManager = signInManager;
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
                    Province = model.Province,
                    District = model.District,
                    Ward = model.Ward,
                    HouseNum = model.HouseNumber
                };
                _context.Add(address);
                await _context.SaveChangesAsync();

                ApplicationUser User = new ApplicationUser()
                {
                    Avatar_Path = UploadedFile(model.iformfile_path),
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
                    return RedirectToAction("Index", "Account");
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
        public IActionResult Login(string returnUrl = "") =>
            View(new LoginViewModel { ReturnUrl = returnUrl });


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

        public JsonResult GetDistrictById(int id) =>
             Json(new SelectList(_context.District.Where(x => x.ProvinceId == id).ToList(), "Id", "Name"));

        public JsonResult GetWardById(int id) =>
             Json(new SelectList(_context.Ward.Where(x => x.DistrictId == id).ToList(), "Id", "Name"));

        private string UploadedFile(IFormFile iformfile_path)
        {
            string uniqueFileName = null;

            if (iformfile_path != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + iformfile_path.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    iformfile_path.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            await _userManager.DeleteAsync(_userManager.FindByIdAsync(Id).Result);
            return RedirectToAction("Datatable", "Account");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {

            var User = _userManager.FindByIdAsync(id).Result;
            var address = _context.Addresses.ToList().Find(el => el.Address_Id == User.Address_Id);

            ModelForEdit model = new ModelForEdit()
            {
                Email = User.Email,
                FullName = User.FullName,
                Id = User.Id,
                Address = address,
                Avatar_Path = User.Avatar_Path,
                PhoneNum = User.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModelForEdit UserModel)
        {
            Address address = _context.Addresses.ToList().Find(x => x.Address_Id == UserModel.Address.Address_Id);

            address.Province = UserModel.Address.Province;
            address.District = UserModel.Address.District;
            address.Ward = UserModel.Address.Ward;
            address.HouseNum = UserModel.Address.HouseNum;

            _context.Update(address);
            await _context.SaveChangesAsync();

            var FindUser = _userManager.FindByIdAsync(UserModel.Id).Result;

            FindUser.Email = UserModel.Email;
            FindUser.FullName = UserModel.FullName;
            FindUser.PhoneNumber = UserModel.PhoneNum;
            FindUser.Address = address;
            FindUser.Avatar_Path = UserModel.Avatar_Path;

            if (UserModel.iformfile_path != null)
            {
                FindUser.Avatar_Path = UploadedFile(UserModel.iformfile_path);

                if (!string.IsNullOrEmpty(UserModel.Avatar_Path))
                {
                    string DelPath = Path.Combine(_hostEnvironment.WebRootPath, "images", UserModel.Avatar_Path);
                    System.IO.File.Delete(DelPath);
                }
            }

            await _userManager.UpdateAsync(FindUser);

            return RedirectToAction("Index", "Account");
        }
    }
}
