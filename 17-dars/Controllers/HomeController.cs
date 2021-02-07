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

        public ViewResult Details()
        {
            Staff model = _staffRepository.Get(3);
            ViewData["staff"] = model;
            ViewBag.title = "Staff Details";
            return View();
        }
        public string Staff()
        {
            return _staffRepository.Get(3)?.FirstName;
        }
    }
}
