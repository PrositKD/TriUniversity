using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EContext: DbContext
    {
        public DbSet<Admin> Admins { get; set; }    
    }
}
