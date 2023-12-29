﻿using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TriUniversity.Controllers
{
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("api/admin/create")]
        public HttpResponseMessage CreateNews([FromBody] AdminDTO adminDto)
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
                var data = AdminService.CreateAdmin(adminDto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        [HttpPost]
        [Route("api/admin/login")]
        public HttpResponseMessage GetAdmin([FromBody] AdminDTO adminDto)
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
                var data = AdminService.GetAdmin(adminDto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
        //student post manage

        [HttpGet]
        [Route("api/admin/post/{postid}")]
        public HttpResponseMessage Getpostbyid(int postid)
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
                var data = AdminService.GetPost(postid);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "post not found");
                }

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }
        [HttpGet]
        [Route("api/admin/posts/approve")]
        public HttpResponseMessage GetApprovePots()
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
                var data = AdminService.GetApprovePosts();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "post not found");
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }
        [HttpGet]
        [Route("api/admin/posts/notapprove")]
        public HttpResponseMessage GetUnApprovePots()
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
                var data = AdminService.GetNotApprovePosts();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "post not found");
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }
        [HttpDelete]
        [Route("api/admin/post/delete/{id}")]
        public HttpResponseMessage DeletePost(int id)
        {
            try
            {
                var success = AdminService.DeletePost(id);
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Post deleted successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Post not found.");
                }
            }
            catch 
            {
                // Log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }

        [HttpPut]
        [Route("api/admin/posts/approve/{id}")]
        public HttpResponseMessage ApprovePost(int id)
        {
            try
            {
                var updatedPost = AdminService.UpdatePostApproval(id);
                if (updatedPost != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedPost);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Post not found.");
                }
            }
            catch 
            {
                // Log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError,  "An error occurred while processing the request.");
            }
        }

        //student manage

        [HttpGet]
        [Route("api/admin/student/{id}")]
        public HttpResponseMessage GetStudentbyid(int id)
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
                var data = AdminService.GetStudent(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "student not found");
                }

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }
        [HttpGet]
        [Route("api/admin/student/approve")]
        public HttpResponseMessage GetApproveStudent()
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
                var data = AdminService.GetApproveStudents();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Student not found");
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }
        [HttpGet]
        [Route("api/admin/student/notapprove")]
        public HttpResponseMessage GetUnApproveStudent()
        {
            try
            {
                // Access properties from the DTO (newsDto) and perform actions accordingly
                var data = AdminService.GetNotApproveStudents();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Student not found");
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }
        [HttpDelete]
        [Route("api/admin/Student/delete/{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            try
            {
                var success = AdminService.DeletePost(id);
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Student deleted successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found.");
                }
            }
            catch {
                // Log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while processing the request.");
            }
        }

        [HttpPut]
        [Route("api/admin/Student/approve/{id}")]
        public HttpResponseMessage ApproveStudent(int id)
        {
            try
            {
                var updatedPost = AdminService.UpdateStudentApproval(id);
                if (updatedPost != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedPost);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found.");
                }
            }
            catch {
                // Log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError,  "An error occurred while processing the request.");
            }
        }


    }
}
