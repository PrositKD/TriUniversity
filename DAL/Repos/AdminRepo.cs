using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, Admin>
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

      
    }
}
