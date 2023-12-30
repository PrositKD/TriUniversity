using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface SRepo<CLASS, ID, RET,ID2>
    {


        RET Create(CLASS obj);

        List<CLASS> GetPosts(ID id);
        CLASS Read(ID id);
        CLASS Reademail(ID2 id);
        RET Update(CLASS obj);

        RET Get(CLASS obj);
        bool Delete(ID id);
       


    }
}
