using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    namespace DAL.Repos
    {
        internal class StudentRepo : Repo, SRepo<Student, int, Student>
        {
            public Student Create(Student obj)
            {
                // Check if an account with the same email already exists
                var existingAccount = db.Students.FirstOrDefault(s => s.Email == obj.Email);

                if (existingAccount != null)
                {
                    // An account with the same email already exists, you can handle this scenario
                    // For example, you can throw an exception or return null to indicate failure
                    return null;
                }

                // Continue with creating a new account
                obj.DateOfAccount = DateTime.Now;
                obj.Active = 1;
                db.Students.Add(obj);

                if (db.SaveChanges() > 0)
                {
                    return obj;
                }

                return null;
            }


            public bool Delete(int id)
            {
                var existingStudent = Read(id);
                if (existingStudent != null)
                {
                    db.Students.Remove(existingStudent);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }

            public Student Get(Student obj)
            {
                var data = db.Students.FirstOrDefault(Student => Student.Password == obj.Password && Student.Email == obj.Email);

                return data;
            }

            public List<Student> GetPost(int id)
            {
                throw new NotImplementedException();
            }

            public List<Student> GetPosts(int id)
            {
                throw new NotImplementedException();
            }

            public Student Read(int id)
            {
                return db.Students.Find(id);
            }

            public List<Type> Read()
            {
                throw new NotImplementedException();
            }

            public Student Update(Student obj)
            {
                var existingStudent = Read(obj.Id);
                db.Entry(existingStudent).CurrentValues.SetValues(obj);
                if (db.SaveChanges() > 0) return obj;
                return null;
            }

            
        }
    }

}