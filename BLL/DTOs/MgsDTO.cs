using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MgsDTO
    {
        public int MgsId { get; set; }

        [Required(ErrorMessage = "Student is required")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Teacher is required")]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public DateTime DateOfMgs { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
        public string Reply { get; set; }
        public DateTime DateOfMgsReply { get; set; }
    }
}
