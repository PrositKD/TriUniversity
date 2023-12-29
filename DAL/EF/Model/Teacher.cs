using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Invalid Gender")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Profession is required")]
        [StringLength(100, ErrorMessage = "Profession length can't exceed 100 characters")]
        public string profession { get; set; }
        [Required(ErrorMessage = "University name is required")]
        [StringLength(100, ErrorMessage = "University name length can't exceed 100 characters")]
        public string universityName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
        
    }
}
