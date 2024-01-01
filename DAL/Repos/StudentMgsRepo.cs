using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentMgsRepo : Repo, IMRepo<StudentMgs, int, StudentMgs>
    {
        public StudentMgs Create(StudentMgs obj)
        {
            if (obj != null)
            {
               // obj.DateOfMgs = DateTime.Now; // Set the DateOfMgs property to the current date and time
                db.StudentMgses.Add(obj);
                db.SaveChanges();

                return obj;
            }

            return null;
        }


        public bool Delete(int id)
        {
            var data = Get(id);
            if (data != null)
            {
                db.StudentMgses.Remove(data);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public StudentMgs Get(int id)
        {
            var emp = db.StudentMgses.FirstOrDefault(sp => sp.MgsId == id);
            return emp;
        }

        public List<StudentMgs> Read(int id)
        {
            var data = db.StudentMgses.Where(em => em.StudentId == id).ToList();
            return data;
        }

        public StudentMgs Update(StudentMgs obj)
        {
            var existing = Get(obj.MgsId);

            if (existing != null)
            {
                try
                {
                   // existing.DateOfMgs = DateTime.Now;
                    existing.Message = obj.Message;
                     // Add this line to update the Reply field

                    db.SaveChanges();

                    return existing;  // Return the updated entity
                }
                catch
                {
                    // Handle exceptions if needed
                    return null;
                }
            }

            return null;
        }

        public StudentMgs UpdateReply(StudentMgs obj)
        {
            var existing = Get(obj.MgsId);

            if (existing != null)
            {
                try
                {
                    existing.DateOfMgsReply = DateTime.Now;
                    existing.Reply = obj.Reply;
                   

                    db.SaveChanges();

                    return existing;  
                }
                catch
                {
                  
                    return null;
                }
            }

            return null;
        }

        public List<StudentMgs> TRead(int id)
        {
            var data = db.StudentMgses.Where(em => em.TeacherId == id).ToList();
            return data;
        }

    }
}
