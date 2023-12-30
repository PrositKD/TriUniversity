using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
 public interface SCoRepo<CLASS, ID, RET, ID2>
    {
        CLASS Create(CLASS obj);

        List<CLASS> GetCourses();

        bool BuyCourse(ID id, ID2 courseId);

        bool Delete(ID id);
    }
}
