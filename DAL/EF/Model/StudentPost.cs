using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class StudentPost
    {


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(5000, ErrorMessage = "Description cannot exceed 5000 characters")]
        public string Description { get; set; }
        [Required]
        public int Approve { get; set; }

        [ForeignKey("Student")]

        public int PostedBy { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        public virtual Student Student { get; set; }

        public virtual ICollection<StudentComment> StudentPosts { get; set; }

        public StudentPost()
        {
            StudentPosts = new List<StudentComment>();

        }



    }
}
