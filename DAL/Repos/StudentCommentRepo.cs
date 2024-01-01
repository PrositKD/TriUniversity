using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentCommentRepo : Repo, SRepo<StudentComment, int, StudentComment, string>
    {
        public StudentComment Create(StudentComment obj)
        {
            obj.Date = DateTime.Now;

            db.StudentComments.Add(obj);

            if (db.SaveChanges() > 0)
            {
                return obj;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var existingComment = Read(id);

            if (existingComment != null)
            {
                db.StudentComments.Remove(existingComment);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public StudentComment Get(StudentComment obj)
        {
            // Assuming you want to retrieve a comment based on certain criteria
            return db.StudentComments.FirstOrDefault(c => c.Comment == obj.Comment);
        }

        public List<StudentComment> GetPosts(int id)
        {
            return db.StudentComments.Where(comment => comment.PostId == id).ToList();
        }

        public StudentComment Read(int id)
        {
            return db.StudentComments.Find(id);
        }

        public StudentComment Reademail(string id)
        {
            throw new NotImplementedException();
        }

        public StudentComment Update(StudentComment obj)
        {
            var existingComment = Read(obj.Id);

            if (existingComment != null)
            {
                db.Entry(existingComment).CurrentValues.SetValues(obj);

                if (db.SaveChanges() > 0)
                {
                    return obj;
                }
            }

            return null;
        }
    }
}
