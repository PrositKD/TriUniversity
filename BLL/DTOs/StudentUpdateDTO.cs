using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{


    
        public class StudentUpdateDTO
        {
            [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
            public string Name { get; set; }

            [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
            public DateTime? DateOfBirth { get; set; }

            [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters")]
            public string Phone { get; set; }

            [StringLength(100, ErrorMessage = "Institution name cannot exceed 100 characters")]
            public string InstitutionName { get; set; }

            [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters")]
            public string Address { get; set; }

            [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 50 characters")]
            public string Password { get; set; }

            [StringLength(50, ErrorMessage = "Gender cannot exceed 50 characters")]
            public string Gender { get; set; }
        }
    }



