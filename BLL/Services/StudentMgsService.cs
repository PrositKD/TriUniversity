using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentMgsService
    {
        public static MgsDTO CreateMgs(MgsDTO MgsDTO)
        {
            // Configure AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MgsDTO, StudentMgs>(); // Map from DTO to entity
                cfg.CreateMap<StudentMgs, MgsDTO>(); // Map from entity to DTO
            });

            var mapper = new Mapper(config);
            var Entity = mapper.Map<StudentMgs>(MgsDTO);

            var addedEntity = DataAccessFactory.StudentMgs().Create(Entity);

            var addedAdminDTO = mapper.Map<MgsDTO>(addedEntity);
            return addedAdminDTO;
        }
        public static List<MgsDTO> GetAllQuestion(int id)
        {
            var data = DataAccessFactory.StudentMgs().Read(id);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentMgs, MgsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<MgsDTO>>(data);
            return ret;
        }



        public static MgsDTO UpdateMgs(UMgsDTO uMgsDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UMgsDTO, StudentMgs>();
                cfg.CreateMap<StudentMgs, MgsDTO>();
            });

            var mapper = new Mapper(config);

            var studentMgsToUpdate = mapper.Map<StudentMgs>(uMgsDTO);

            // Assuming UMgsDTO has fields like MgsId, Message, Reply that you want to update

            var result = DataAccessFactory.StudentMgs().Update(studentMgsToUpdate);

            if (result != null)
            {
                var updatedMgsDTO = mapper.Map<MgsDTO>(result);
                return updatedMgsDTO;
            }

            return null; // or throw an exception, depending on your error handling strategy
        }
        public static MgsDTO UpdateMgsReply(ReplyMgsDto uMgsDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReplyMgsDto, StudentMgs>();
                cfg.CreateMap<StudentMgs, MgsDTO>();
            });

            var mapper = new Mapper(config);

            var studentMgsToUpdate = mapper.Map<StudentMgs>(uMgsDTO);

            

            var result = DataAccessFactory.StudentMgs().UpdateReply(studentMgsToUpdate);

            if (result != null)
            {
                var updatedMgsDTO = mapper.Map<MgsDTO>(result);
                return updatedMgsDTO;
            }

            return null; 
        }


        public static List<MgsDTO> GetAllMgs(int id)
        {
            var data = DataAccessFactory.StudentMgs().TRead(id);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentMgs, MgsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<MgsDTO>>(data);
            return ret;
        }





        public static string DeleteQuestion(int email)
        {
            var result = DataAccessFactory.StudentMgs().Delete(email);
            return result ? "Delete successfully" : "Failed";
        }

       
    }
}
