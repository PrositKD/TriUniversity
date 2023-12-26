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
    public class StudentPostService
    {
        public static List<StudentPostDTO> GetPosts(int id)
        {
            var data = DataAccessFactory.StudentPostData().GetPosts(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentPost, StudentPostDTO>();
            });

            var mapper = new Mapper(config);

            var postDTOs = mapper.Map<List<StudentPostDTO>>(data);
            return postDTOs;
        }
        public static StudentPostDTO GetPost(int id)
        {
            var data = DataAccessFactory.StudentPostData().Read(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentPost, PostCommentDto>(); 
                cfg.CreateMap<StudentComment, StudentCommentDTO>(); 
            });

            var mapper = new Mapper(config);

            var postDTOs = mapper.Map<PostCommentDto>(data);
            return postDTOs;
        }
    }
}
