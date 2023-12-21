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
        public static bool CreateAdmin(AdminDTO adminDTO)
        {
           
            // Configure AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>(); // Map from DTO to entity
                                                  // Add additional mappings if needed
            });

            // Create mapper instance
            var mapper = new Mapper(config);

            // Map the input DTO to an entity
            var adminEntity = mapper.Map<Admin>(adminDTO);

            // Pass the mapped entity to the repository's Add method
            return DataAccessFactory.AdminData().Add(adminEntity);
        }
    }
}
