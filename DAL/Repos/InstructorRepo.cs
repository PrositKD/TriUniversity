using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class InstructorRepo : Repo, InRepo<Teacher, string, Teacher>, IAuth<bool>
    {
        public List<Teacher> All()
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(string email, string password)
        {
            var data = db.Teachers.FirstOrDefault(u => u.email.Equals(email) && u.password.Equals(password));
            if (data == null) return true;
            return false;
        }

        public Teacher create(Teacher obj)
        {
            db.Teachers.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool delete(string key)
        {
            throw new NotImplementedException();
        }

        public Teacher get(string email)
        {
            var teacher = db.Teachers.FirstOrDefault(t => t.email == email);
            return teacher;
        }

        public bool update(Teacher obj)
        {
            throw new NotImplementedException();
        }
    }
}
