using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PostCommentDto:StudentPostDTO
    {
        
        public PostCommentDto() {
            StudentPosts = new List<StudentCommentDTO>();
        }
        public List<StudentCommentDTO> StudentPosts { get; set; }
    }
}
