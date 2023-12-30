using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentCommentRepo : Repo, SRepo<StudentComment, int, StudentComment,string>
    {
        public StudentComment Create(StudentComment obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public StudentComment Get(StudentComment obj)
        {
            throw new NotImplementedException();
        }

        public List<StudentComment> GetPosts(int id)
        {
            throw new NotImplementedException();
        }

        public StudentComment Read(int id)
        {
            throw new NotImplementedException();
        }

        public StudentComment Reademail(string id)
        {
            throw new NotImplementedException();
        }

        public StudentComment Update(StudentComment obj)
        {
            throw new NotImplementedException();
        }
    }
}
   
