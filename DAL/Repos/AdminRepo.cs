using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, bool>
    {
        public bool Add(Admin obj)
        {
            db.Admins.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }


        public bool Get(Admin obj)
        {
            
             var data = db.Admins.FirstOrDefault(admin => admin.Id == obj.Id && admin.Email == obj.Email);

             return data != null;
        }

        
    }
}
