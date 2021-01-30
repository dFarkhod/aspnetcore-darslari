using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public JsonResult Data()
        {
            return Json(new { id = 17, firstName = "Jaloliddin", lastName = "Rumiy" });
        }


    }
}
