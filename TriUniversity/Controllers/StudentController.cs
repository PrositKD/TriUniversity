using BLL.DTOs;
using BLL.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using TriUniversity.Auth;
using static BLL.Services.StudentService;
using System.Threading.Tasks;

namespace TriUniversity.Controllers
{
    public class StudentController : ApiController
    {
        [HttpPost]
        [Route("api/student/create")]
        public HttpResponseMessage CreateNews([FromBody] StudentDTO sDto)
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
                var data = StudentService.CreateStudent(sDto);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Email already register");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [HttpGet]
        [Route("api/student/posts/{studentid}")]
        public HttpResponseMessage Getallpostbyid(int studentid)
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
                var data = StudentPostService.GetPosts(studentid);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }

                return Request.CreateResponse(HttpStatusCode.OK, "post not found");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }
        [Logged]
        [HttpGet]
        [Route("api/student/post/{postid}")]
        public HttpResponseMessage Getpostbyid(int postid)
        {
            try
            {
                var data = StudentPostService.GetPost(postid);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }

                return Request.CreateResponse(HttpStatusCode.OK, "post not found");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }
        [Logged]
        [HttpPost]
        [Route("api/student/create-post")]
        public HttpResponseMessage CreatePost([FromBody] StudentPostDTO postDTO)
        {
            try
            {
                
                StudentPostService.CreatePost(postDTO);

                return Request.CreateResponse(HttpStatusCode.OK, "Post created successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Error creating post: {ex.Message}");
            }
        }
        [Logged]
        [HttpDelete]
        [Route("api/student/delete-post/{postId}")]
        public HttpResponseMessage DeletePost(int postId)
        {
            try
            {
                var isDeleted = StudentPostService.DeletePost(postId);

                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Post deleted successfully");
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, "Post not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Error deleting post: {ex.Message}");
            }
        }

        [Logged]
        [HttpPut]
        [Route("api/student/update/{studentId}")]
        public HttpResponseMessage UpdateStudentProfile(int studentId, [FromBody] StudentUpdateDTO updatedDto)
        {
            try
            {
                var updatedData = StudentUpdateService.UpdateStudentProfile(studentId, updatedDto);

                if (updatedData != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedData);
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                Console.WriteLine(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while processing the request");
            }
        }
        [Logged]
        [HttpDelete]
        [Route("api/student/delete/{studentId}")]
        public HttpResponseMessage DeleteStudentAccount(int studentId)
        {
            try
            {
                var isDeleted = StudentService.DeleteStudentAccount(studentId);

                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Student account deleted successfully");
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
       
        [HttpPost]
        [Route("api/student/login")]
        public HttpResponseMessage Login(SLoginModel login)
        {
            try
            {
                var res = SAuthService.Authenticatee(login.Email, login.Password);

                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }



        }
        [Logged]
        [HttpPost]
        [Route("api/student/logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
              
                var token = HttpContext.Current.Request.Headers["Authorization"];

                if (token == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Token not provided in the header" });
                }

                var isLoggedOut = SAuthService.Logout(token);

                if (isLoggedOut)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Logout successful" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Token not found or unable to logout" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }


        }
      
        [HttpGet]
        [Route("api/courses")]
        public HttpResponseMessage GetAllCourses()
        {
            try
            {
                var data = StudentCourseService.GetAllCourses();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }
        [Logged]
        [HttpPost]
        [Route("api/student/buy-course")]
        public HttpResponseMessage BuyCourse([FromBody] OrderCourseDTO orderDTO)
        {
            try
            {
                var isBought = StudentCourseService.BuyCourse(orderDTO.StudentId, orderDTO.CourseId);

                if (isBought)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Course bought successfully");
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to buy the course");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/course/download/{courseId}")]
        public HttpResponseMessage courseDownload(int courseId)
        {
            try
            {
                string courseName = CourseService.findCoursId(courseId);
                if (courseName != null)
                {


                    var result = new HttpResponseMessage(HttpStatusCode.OK);

                    var fileName = courseName;
                    var filePath = HttpContext.Current.Server
                        .MapPath($"~/App_Data/{fileName}");

                    var fileBytes = File.ReadAllBytes(filePath);

                    var fileMemStream =
                        new MemoryStream(fileBytes);

              
                    result.Content = new StreamContent(fileMemStream);

                   
                    var headers = result.Content.Headers;

                    headers.ContentDisposition =
                        new ContentDispositionHeaderValue("attachment");
                    headers.ContentDisposition.FileName = fileName;

                    headers.ContentType =
                       
                        new MediaTypeHeaderValue("application/octet-stream");

                    headers.ContentLength = fileMemStream.Length;

                    return result;



                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "You did not buy the course" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.ToString());
            }

        }


    }
}







