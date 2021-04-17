using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IWebHostEnvironment webHost;

        public HomeController(IStaffRepository staffRepository, IWebHostEnvironment webHost)
        {
            _staffRepository = staffRepository;
            this.webHost = webHost;
        }

        public ViewResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Staffs = _staffRepository.GetAll()
            };
            return View(viewModel);
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Staff = _staffRepository.Get(id??1),
                Title = "Staff Details"
            };

            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HomeCreateViewModel staff)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = string.Empty;
                if (staff.Photo != null)
                {
                    string uploadFolder = Path.Combine(webHost.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.Photo.FileName;
                    string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                    staff.Photo.CopyTo(new FileStream(imageFilePath, FileMode.Create));
                }

                Staff newStaff = new Staff
                {
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Email = staff.Email,
                    Department = staff.Department,
                    PhotoFilePath = uniqueFileName
                };

                newStaff = _staffRepository.Create(newStaff);
                return RedirectToAction("details", new { id = newStaff.Id });
            }

            return View();
        }

    }
}
