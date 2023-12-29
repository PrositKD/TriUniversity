using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IASRepo<CLASS, ID, RET>
    {




        List<CLASS> Read();
        List<CLASS> NotApprove();

        CLASS GetID(ID id);
        RET Update(ID id);

        bool Delete(ID id);


    }
}
