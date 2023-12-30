using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderCourseDTO
    {

            [Required(ErrorMessage = "StudentId is required")]
            public int StudentId { get; set; }

            [Required(ErrorMessage = "CourseId is required")]
            public int CourseId { get; set; }

            [Required(ErrorMessage = "DateOfBuying is required")]
            [DataType(DataType.DateTime, ErrorMessage = "Invalid date format")]
            public DateTime DateOfBuying { get; set; }
        }
    }
