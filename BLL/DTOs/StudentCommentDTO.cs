using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
     public class StudentCommentDTO
    {
        public int Id { get; set; }

        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]

        public string CommentedBy { get; set; }
        [Required]
        
        public int PostId { get; set; }

        
    }
}
