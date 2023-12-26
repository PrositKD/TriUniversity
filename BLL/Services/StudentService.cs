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
    public class StudentService
    {

        public static StudentDTO CreateStudent(StudentDTO sDTO)
        {
            // Configure AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, Student>(); // Map from DTO to entity
                cfg.CreateMap<Student, StudentDTO>(); // Map from entity to DTO
            });

            // Create mapper instance
            var mapper = new Mapper(config);

            // Map the input DTO to an entity
            var studentEntity = mapper.Map<Student>(sDTO);

            // Pass the mapped entity to the repository's Add method
            var addedEntity = DataAccessFactory.StudentData().Create(studentEntity);

            // Map the added entity back to DTO
            var addedSDTO = mapper.Map<StudentDTO>(addedEntity);

            // Return the DTO
            return addedSDTO;
        }

    }
}
