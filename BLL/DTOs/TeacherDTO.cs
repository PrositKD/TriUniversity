using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string profession { get; set; }
        public string universityName { get; set; }
        public string password { get; set; }
    }
}
