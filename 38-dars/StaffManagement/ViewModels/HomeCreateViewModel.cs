using Microsoft.AspNetCore.Http;
using StaffManagement.Attributes;
using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.ViewModels
{
    public class HomeCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Department")]
        public Departments? Department { get; set; }

        [MaxFileSize(800)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile Photo { get; set; }
    }
}
