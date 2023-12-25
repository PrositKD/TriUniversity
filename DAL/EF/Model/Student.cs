using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "Institution name cannot exceed 100 characters")]
        public string InstitutionName { get; set; }

        [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 50 characters")]
        public string Password { get; set; }

        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid gender")]
        public Gender Gender { get; set; }
        [Required]
        public int Active { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
