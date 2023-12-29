using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Repos.AdminStudentRepo;

namespace DAL.Repos
{
    internal class AdminStudentRepo : Repo, IASRepo<Student, int, Student, AdminAgeRangeResult>
    {
        public bool Delete(int id)
        { // Find the StudentPost by ID
            var student = GetID(id);

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
            var data = db.Students.Where(student => student.Active == 1).ToList();

            return data;
        }
        public List<Student> NotApprove()
        {
            var data = db.Students.Where(student => student.Active == 0).ToList();

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



        public List<AdminAgeRangeResult> ReadMonthly()
        {
            try
            {
                var currentDate = DateTime.Today;

                var data = db.Students
                    .Where(student => student.DateOfBirth != null)
                    .ToList();

                var groupedData = data
                    .GroupBy(student => CalculateAgeRange(student.DateOfBirth, currentDate))
                    .Select(group => new AdminAgeRangeResult
                    {
                        Range = group.Key,
                        Count = group.Count()
                    })
                    .ToList();

                Console.WriteLine($"Number of age groups after grouping: {groupedData.Count}");

                return groupedData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ReadMonthly: {ex.Message}");
                throw; // Rethrow the exception to indicate that an error occurred
            }
        }




        private string CalculateAgeRange(DateTime dateOfBirth, DateTime currentDate)
        {
            int age = currentDate.Year - dateOfBirth.Year;

            // Adjust age if birthday hasn't occurred yet this year
            if (currentDate < dateOfBirth.AddYears(age))
            {
                age--;
            }

            // Define age ranges
            if (age < 15)
            {
                return "14 and low";
            }
           else if (age >= 15 && age < 20)
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

            // If the age doesn't fall into any predefined range, you can handle it accordingly
            return "Unknown";
        }



    }
}