using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo<CLASS, ID, RET,ID2>
    {


      
        RET Get(CLASS obj);
        bool Delete(ID id);
        RET Add(CLASS obj);
        CLASS Reademail(ID2 id);

    }
}
