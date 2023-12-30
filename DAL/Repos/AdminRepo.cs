using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, Admin,String>, SAuth<bool>
    {
        public Admin Add(Admin obj)
        {
            db.Admins.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Admin Get(Admin obj)
        {
            var data = db.Admins.FirstOrDefault(admin => admin.Password == obj.Password && admin.Email == obj.Email);

            return data;
        }
        public bool Authenticatee(string Email, string password)
        {
            var data = db.Admins.FirstOrDefault(e => e.Email.Equals(Email) && e.Password.Equals(password));

            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Admin Reademail(string id)
        {

            return db.Admins.Where(student => student.Email == id).FirstOrDefault();
        }
    }
}
