using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System.Collections.Generic;

namespace BLL.Services
{
    public class StudentCourseService

    {
        public static List<StudentCourseDTO> GetAllCourses()
        {
            var data = DataAccessFactory.StudentCourseData().GetCourses();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, StudentCourseDTO>();
            });

            var mapper = new Mapper(config);

            var courseDTOs = mapper.Map<List<StudentCourseDTO>>(data);
            return courseDTOs;
        }
    }
}


