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
    public class StudentMgsController : ApiController
    {
        [HttpGet]
        [Route("api/Student/mgs/{id}")]
        public HttpResponseMessage GetAllMgs(int id)
        {
            try
            {
                var data = StudentMgsService.GetAllQuestion(id);

                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Data not found.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/student/mgs/create")]
        public HttpResponseMessage UpdateQuestion(MgsDTO ss)
        {
            try
            {
                var updatedPost = StudentMgsService.CreateMgs(ss);
                if (updatedPost != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedPost);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, " Faild to create.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }




        [HttpPut]
        [Route("api/student/mgs/update")]
        public HttpResponseMessage UpdateQuestion(UMgsDTO ss)
        {
            try
            {
                var updatedPost = StudentMgsService.UpdateMgs(ss);
                if (updatedPost != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedPost);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, " no update found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
        
        [HttpPut]
        [Route("api/teacher/mgs/reply")]
        public HttpResponseMessage UpdateMgs(ReplyMgsDto ss)
        {
            try
            {
                var updatedPost = StudentMgsService.UpdateMgsReply(ss);
                if (updatedPost != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedPost);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, " no mgs found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/teacher/mgs/{id}")]
        public HttpResponseMessage GetAllMgsReply(int id)
        {
            try
            {
                var data = StudentMgsService.GetAllMgs(id);

                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Data not found.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete]
        [Route("api/Student/mgs/Delete/{id}")]
        public HttpResponseMessage DeleteQuestion(int id)
        {
            try
            {
                var result = StudentMgsService.DeleteQuestion(id);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
