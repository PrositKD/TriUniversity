using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static BLL.Services.StudentService;

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
                var data =StudentPostService.GetPosts(studentid);
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
        [HttpGet]
        [Route("api/student/post/{postid}")]
        public HttpResponseMessage Getpostbyid(int postid)
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
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



    }
}




