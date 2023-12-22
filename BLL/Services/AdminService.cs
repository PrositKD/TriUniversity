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
    public class AdminService
    {
        public static AdminDTO CreateAdmin(AdminDTO adminDTO)
        {
            // Configure AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>(); // Map from DTO to entity
                cfg.CreateMap<Admin, AdminDTO>(); // Map from entity to DTO
            });

            // Create mapper instance
            var mapper = new Mapper(config);

            // Map the input DTO to an entity
            var adminEntity = mapper.Map<Admin>(adminDTO);

            // Pass the mapped entity to the repository's Add method
            var addedAdminEntity = DataAccessFactory.AdminData().Add(adminEntity);

            // Map the added entity back to DTO
            var addedAdminDTO = mapper.Map<AdminDTO>(addedAdminEntity);

            // Return the DTO
            return addedAdminDTO;
        }


        public static object  GetAdmin(AdminDTO adminDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });

            var mapper = new Mapper(config);

            var adminEntity = mapper.Map<Admin>(adminDTO);
            var result = DataAccessFactory.AdminData().Get(adminEntity);
            var addedAdminDTO = mapper.Map<AdminDTO>(result);

            if (addedAdminDTO != null)
            {
                var message = new
                {
                    Status = "User found",
                    Email = addedAdminDTO.Email
                };
                return (message);
            }
            else
            {
                var message = new
                {
                    Status = "User not found"
                };
                return (message);
            }
        }




    }
}
