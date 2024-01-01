using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class MonthlyEarning
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalEarnings { get; set; }
    }
}
