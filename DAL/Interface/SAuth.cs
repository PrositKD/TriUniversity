using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface SAuth<Ret>
    {
        Ret Authenticatee(string Email, string password);
    }
}