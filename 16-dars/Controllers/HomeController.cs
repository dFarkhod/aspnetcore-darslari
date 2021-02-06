using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaffRepository _staffRepository;

        public HomeController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult ViewOne()
        {
            return View("View1");
        }
        public ViewResult ViewTwo()
        {
            return View("../Other/View2");
        }
        public ViewResult ViewThree()
        {
            return View("~/Top/View3.cshtml");
        }

        public JsonResult Data()
        {
            return Json(new { id = 17, firstName = "Jaloliddin", lastName = "Rumiy" });
        }

        public string Staff()
        {
            return _staffRepository.Get(3)?.FirstName;
        }


    }
}
