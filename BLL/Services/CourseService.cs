using AutoMapper;
using BLL.DTOs;
using DAL.EF.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseService
    {

        public static string CreateCourse(string token)
        {
            var res = DataAccessFactory.TokenData().get(token);
            if (res != null)
            {
                var userId = res.UserId;

                if (res != null) return userId;
            }
            return null;


        }


        public static CourseDTO CreateCourseSure(CourseDTO courseDTO, string fileName, string res)
        {


            var course = new Course();
            course.Name = courseDTO.Name;
            course.ShortDescription = courseDTO.ShortDescription;
            course.Duration = courseDTO.Duration;
            course.ApproveOrNot = false;
            course.InstructorName = courseDTO.InstructorName;
            course.VideoPath = fileName;
            course.Price = courseDTO.Price;
            course.SellCount = 0;
            course.UploadTime = DateTime.Now;
            course.userId = int.Parse(res);

            var ret = DataAccessFactory.CourseData().create(course);
            if (ret != null)
            {
                var cfg = new MapperConfiguration(c => {
                    c.CreateMap<Course, CourseDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<CourseDTO>(ret);
            }
            return null;
        }

        public static string findCoursId(int courseId)
        {
            var res = DataAccessFactory.courseData().courseInformation(courseId);
            if (res != null)
            {
                var courseName = res.VideoPath;

                if (res != null) return courseName;
            }
            return null;


        }
        public static int findCoursIdd(int courseId)
        {
            var res = DataAccessFactory.courseData().courseInformation(courseId);
            if (res != null)
            {
                var realCourseId = res.Id;

                if (res != null) return realCourseId;
            }
            return 0;


        }
        

        public static List<decimal> earning(int courseId)
        {
            List<decimal> monthlyIncome = DataAccessFactory.coursedata().CalculateMonthlyIncome(courseId);

            return monthlyIncome;

        }
    }
}

