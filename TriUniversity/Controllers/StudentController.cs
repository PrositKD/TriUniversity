using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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


    }
}
