using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Staff> Staffs { get; set; }
    }
}
