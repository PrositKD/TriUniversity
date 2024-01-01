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
        public static void CreatePost(StudentPostDTO postDTO)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentPostDTO, StudentPost>();
            });

            var mapper = new Mapper(config);
            var postEntity = mapper.Map<StudentPost>(postDTO);


            postEntity.Date = DateTime.Now;


            DataAccessFactory.StudentPostData().Create(postEntity);
        }

        public static bool DeletePost(int postId)
        {
            try
            {

                var postToDelete = DataAccessFactory.StudentPostData().Read(postId);

                if (postToDelete == null)
                {

                    return false;
                }

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<StudentPost, StudentPostDTO>();
                });

                var mapper = new Mapper(config);
                var postDTO = mapper.Map<StudentPostDTO>(postToDelete);


                DataAccessFactory.StudentPostData().Delete(postId);

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting post: {ex.Message}");
                return false;
            }
        }
    }
}
