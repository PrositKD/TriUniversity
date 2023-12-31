using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminCourseRepo : Repo, IASRepo<Course, int, Course, AdminAgeRangeResult>
    {
        public bool Delete(int id)
        {
            var cPost = GetID(id);

            if  (cPost != null)
            {

                db.Courses.Remove(cPost);
                db.SaveChanges();
                return true; // Deletion successful
            }

            return false;
        }

        public Course GetID(int id)
        {
            var studentPost = db.Courses.FirstOrDefault(sp => sp.Id == id);
            return studentPost;
        }

        public List<Course> NotApprove()
        {
            var data = db.Courses.Where(studentPost => studentPost.ApproveOrNot==false).ToList();

            return data;
        }

        public List<Course> Read()
        {
            var data = db.Courses.Where(studentPost => studentPost.ApproveOrNot == true).ToList();

            return data;
        }

        public List<AdminAgeRangeResult> ReadMonthly()
        {
            try
            {
                var groupedData = db.Courses
                    .GroupBy(course => course.TeacherId)
                    .Select(group => new AdminAgeRangeResult
                    {
                        Id = group.Key,
                        Count = group.Count()
                    })
                    .ToList();

                return groupedData;
            }
            catch 
            {
               return null;
               
            }
        }

        public Course Update(int id)
        {
            var studentPost = db.Courses.FirstOrDefault(sp => sp.Id == id);

            if (studentPost != null)
            {
                // Update the Approve property
                studentPost.ApproveOrNot = (studentPost.ApproveOrNot == false) ? true : false;
                db.SaveChanges();
            }

            return studentPost;
        }
    }
}