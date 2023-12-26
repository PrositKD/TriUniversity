using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentPostRepo : Repo, SRepo<StudentPost, int, StudentPost>
    {
        public StudentPost Create(StudentPost obj)
        {
            obj.Date = DateTime.Now;
            obj.Approve = 0;
            db.StudentPosts.Add(obj);

            if (db.SaveChanges() > 0)
            {
                return obj;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var existingPost = Read(id);
            if (existingPost != null)
            {
                db.StudentPosts.Remove(existingPost);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public StudentPost Get(StudentPost obj)
        {
            throw new NotImplementedException();
        }

        public StudentPost Read(int id)
        {
            return db.StudentPosts.Find(id);
        }

        public List<StudentPost> GetPosts(int id)
        {
            return db.StudentPosts.Where(StudentPost=>StudentPost.PostedBy==id).ToList();
        }

        public StudentPost Update(StudentPost obj)
        {
            var existingPost = Read(obj.Id);
            db.Entry(existingPost).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public List<StudentPost> GetPost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
