using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.ViewModels;
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
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Staffs = _staffRepository.GetAll()
            };
            return View(viewModel);
        }

        public ViewResult Details()
        {
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Staff = _staffRepository.Get(3),
                Title = "Staff Details"
            };

            return View(viewModel);
        }
        public string Staff()
        {
            return _staffRepository.Get(3)?.FirstName;
        }
    }
}
