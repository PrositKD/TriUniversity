using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseRepo : Repo, InRepo<Course, string, Course>, Dcourse<Course>, mEarningRepo
    {
        public List<Course> All()
        {
            throw new NotImplementedException();
        }

        public List<decimal> CalculateMonthlyIncome(int courseId)
        {
            var orders = db.Orders.Where(o => o.CourseId == courseId && o.DateOfBuying.Year == DateTime.Now.Year)
                                  .ToList();

            List<decimal> monthlyIncome = new List<decimal>(new decimal[12]);

            foreach (var order in orders)
            {
                int month = order.DateOfBuying.Month;
                var course = db.Courses.FirstOrDefault(c => c.Id == order.CourseId);
                if (course != null)
                {
                    decimal coursePrice = course.Price;
                    monthlyIncome[month - 1] += coursePrice;
                }
            }

            return monthlyIncome;
        }

        public Course courseInformation(int courseId)
        {
            var course = db.Courses.FirstOrDefault(t => t.Id == courseId);
            return course;
        }

        public Course create(Course obj)
        {
            db.Courses.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool delete(string key)
        {
            throw new NotImplementedException();
        }



        public Course get(string key)
        {
            throw new NotImplementedException();
        }

        public bool update(Course obj)
        {
            throw new NotImplementedException();
        }
    }
}
