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

        public class StudentUpdateService
        {
            public static StudentDTO UpdateStudentProfile(int studentId, StudentUpdateDTO updatedDto)
            {
                try
                {
                    // AutoMapper configuration
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<StudentUpdateDTO, Student>(); // Map from UpdateDTO to entity
                        cfg.CreateMap<Student, StudentDTO>(); // Map from entity to DTO
                    });

                    // Create mapper instance
                    var mapper = new Mapper(config);

                    // Retrieve the existing student entity from the repository
                    var existingEntity = DataAccessFactory.StudentData().Read(studentId);

                    if (existingEntity == null)
                    {
                        // Handle the case where the student with the given ID is not found
                        return null;
                    }

                    // Update the existing entity with the new data from the updated DTO
                    mapper.Map(updatedDto, existingEntity);

                    // Pass the updated entity to the repository's Update method
                    var updatedEntity = DataAccessFactory.StudentData().Update(existingEntity);

                    // Map the updated entity back to DTO
                    var updatedSDTO = mapper.Map<StudentDTO>(updatedEntity);

                    // Return the updated DTO
                    return updatedSDTO;
                }
                catch (Exception ex)
                {
                    // Log the exception for debugging purposes
                    // You can use a logging framework or Console.WriteLine for simplicity
                    Console.WriteLine(ex.Message);
                    throw; // Re-throw the exception to let it propagate and return a 500 error
                }
            }
        }
        public static bool DeleteStudentAccount(int studentId)
        {
            // Retrieve the existing student entity from the repository
            var existingEntity = DataAccessFactory.StudentData().Read(studentId);

            if (existingEntity == null)
            {
                // Handle the case where the student with the given ID is not found
                return false;
            }

            // Delete the existing entity from the repository
            var isDeleted = DataAccessFactory.StudentData().Delete(studentId);

            return isDeleted;
        }

    }


}




