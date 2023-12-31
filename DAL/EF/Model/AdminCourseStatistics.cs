using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class AdminCourseStatistics
    {
        public int CourseId { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalSalePrice { get; set; }
    }
}
