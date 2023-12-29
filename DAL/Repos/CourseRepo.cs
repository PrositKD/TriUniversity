using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseRepo : Repo, InRepo<Course, string, Course>
    {
        public List<Course> All()
        {
            throw new NotImplementedException();
        }

        public Course create(Course obj)
        {
            throw new NotImplementedException();
        }

        public bool delete(string key)
        {
            throw new NotImplementedException();
        }

        public Course get(string key)
        {
            throw new NotImplementedException();
        }

        public bool update(Course obj)
        {
            throw new NotImplementedException();
        }
    }
}
