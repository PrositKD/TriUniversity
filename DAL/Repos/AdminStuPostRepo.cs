using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminStuPostRepoRepo : Repo, IASRepo<StudentPost, int, StudentPost, AdminAgeRangeResult>
    {
        public bool Delete(int id)
        {
            // Find the StudentPost by ID
            var studentPost = GetID(id);

            if (studentPost != null)
            {

                db.StudentPosts.Remove(studentPost);
                db.SaveChanges();
                return true; // Deletion successful
            }

            return false; // StudentPost with the specified ID not found
        }


        public StudentPost GetID(int id)
        {
            var studentPost = db.StudentPosts.FirstOrDefault(sp => sp.Id == id);
            return studentPost;
        }

        public List<StudentPost> Read()
        {
            var data = db.StudentPosts.Where(studentPost => studentPost.Approve == 1).ToList();

            return data;
        }
        public List<StudentPost> NotApprove()
        {
            var data = db.StudentPosts.Where(studentPost => studentPost.Approve == 0).ToList();

            return data;
        }

        public StudentPost Update(int id)
        {
            // Find the StudentPost by ID
            var studentPost = db.StudentPosts.FirstOrDefault(sp => sp.Id == id);

            if (studentPost != null)
            {
                // Update the Approve property
                studentPost.Approve = (studentPost.Approve == 0) ? 1 : 0;
                db.SaveChanges();
            }

            return studentPost;
        }

        
        public List<AdminAgeRangeResult> ReadMonthly()
        {
            try
            {
                var groupedData = db.StudentPosts
                    .GroupBy(post => post.PostedBy)
                    .Select(group => new AdminAgeRangeResult
                    {
                        Id = group.Key,
                        Count = group.Count()
                    })
                    .ToList();

              

                return groupedData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetPostedByPostCounts: {ex.Message}");
                throw; // Rethrow the exception to indicate that an error occurred
            }
        }
    }
}

