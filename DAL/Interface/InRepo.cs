using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface InRepo<classType, idType, returnType>
    {
        List<classType> All();
        classType get(idType key);
        returnType create(classType obj);
        bool update(classType obj);

        bool delete(idType key);
       
    }
}
