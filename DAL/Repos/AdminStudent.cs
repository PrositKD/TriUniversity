using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminStudent : Repo, IASRepo<Student, int, Student>
    {
        public bool Delete(int id)
        { // Find the StudentPost by ID
            var student = GetID( id);

            if (student != null)
            {
                // Remove the StudentPost from the database
                db.Students.Remove(student);
                db.SaveChanges();
                return true; 
            }

            return false;
        }

        public Student GetID(int id)
        {
            var student = db.Students.FirstOrDefault(sp => sp.Id == id);
            return student;
        }

        public List<Student> Read()
        {
            var data = db.Students.Where(student=> student.Active == 1).ToList();

            return data;
        } 
        public List<Student> ReadBlock()
        {
            var data = db.Students.Where(student=> student.Active == 0).ToList();

            return data;
        }
        

        public Student Update(int id)
        {
            var studentPost = db.Students.FirstOrDefault(sp => sp.Id == id);

            if (studentPost != null)
            {
                // Update the Approve property
                studentPost.Active = (studentPost.Active == 0) ? 1 : 0;
                db.SaveChanges();
            }

            return studentPost;
        }

        public List<object> ReadMonthly()
        {
            var currentDate = DateTime.Today;

            var data = db.Students
                .Where(student => student.DateOfBirth != null)
                .GroupBy(student => CalculateAgeRange(student.DateOfBirth, currentDate))
                .Select(group => new
                {
                    Range = group.Key,
                    Count = group.Count()
                })
                .ToList<object>();

            return data;
        }

        private string CalculateAgeRange(DateTime? dateOfBirth, DateTime currentDate)
        {
            if (dateOfBirth.HasValue)
            {
                int age = currentDate.Year - dateOfBirth.Value.Year;

                // Adjust age if birthday hasn't occurred yet this year
                if (currentDate < dateOfBirth.Value.AddYears(age))
                {
                    age--;
                }

                // Define age ranges
                if (age >= 15 && age < 20)
                {
                    return "15-19 years";
                }
                else if (age >= 20 && age < 25)
                {
                    return "20-24 years";
                }
                else if (age >= 25 && age <= 30)
                {
                    return "25-30 years";
                }
                else if (age > 30)
                {
                    return "30 and up";
                }
                // Handle other cases as needed

                // If the age doesn't fall into any predefined range, you can handle it accordingly
            }

            return "Unknown"; // Handle cases where DateOfBirth is null or unexpected
        }


    }
}

