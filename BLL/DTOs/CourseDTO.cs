using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name length can't exceed 100 characters")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description length can't exceed 500 characters")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Instructor name is required")]
        [StringLength(100, ErrorMessage = "Instructor name length can't exceed 100 characters")]
        public string InstructorName { get; set; }

        [Required(ErrorMessage = "Price is required")]

        public int Price { get; set; }

        [Required(ErrorMessage = "Duration is required")]

        public int Duration { get; set; }

        [Required(ErrorMessage = "Video path is required")]
        [StringLength(200, ErrorMessage = "Video path length can't exceed 200 characters")]
        public string VideoPath { get; set; }

        [Display(Name = "Upload Time")]
        [DataType(DataType.DateTime)]
        public DateTime UploadTime { get; set; }

        [Display(Name = "Status")]
        public bool ApproveOrNot { get; set; }

        [Display(Name = "Sell Count")]
        [Range(0, int.MaxValue, ErrorMessage = "Sell count must be a non-negative value")]
        public int SellCount { get; set; }
        public int userId { get; set; }
    }
}
