using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminStuPostRepoRepo : Repo, IASRepo<StudentPost, int, StudentPost>
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
        var data = db.StudentPosts.Where(studentPost => studentPost.Approve == 0).ToList();

        return data;
    }
    public List<StudentPost> ApprovePosts()
    {
        var data = db.StudentPosts.Where(studentPost => studentPost.Approve == 1).ToList();

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


}
}
