using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyWebApplication.Models;
using PharmacyWebApplication.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWebApplication.Controllers
{
    public class RegisterInfoController : Controller
    {
        private readonly PharmacyDBContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public RegisterInfoController(PharmacyDBContext context, IWebHostEnvironment hostEnvironment)
        {
            this._context = context;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var a = _context.User.ToList();
            return View(a);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ProvinceList = new SelectList(_context.Province.ToList(), "Id", "Name");
            return View();
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

        [HttpPost]
        public async Task<IActionResult> Create(ModelForCreate model)
        {
            User user = new User()
            {
                FullName = model.FullName,
                Email = model.Email,
                PhoneNum = model.PhoneNum,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                /*Address = address,*/
                //Avatar_Path = UploadedFile(model)
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            Address address = new Address()
            {
                Province = _context.Province.ToList().Find(x => x.Id == model.Province).Name,
                District= _context.District.ToList().Find(x => x.Id == model.District).Name,
                Ward = _context.Ward.ToList().Find(x => x.Id == model.Ward).Name,
                HouseNumber = model.HouseNumber,
                User= user
            };

            _context.Address.Add(address);
            await _context.SaveChangesAsync();

           
            return View();
        }

        private string UploadedFile(ModelForCreate model)
        {
            string uniqueFileName = null;

            if (model.iformfile_path != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "images");
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
