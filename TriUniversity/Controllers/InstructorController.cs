using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace TriUniversity.Controllers
{
    public class InstructorController : ApiController
    {

        [HttpPost]
        [Route("api/instructor/create")]
        public HttpResponseMessage CreateInstructor([FromBody] TeacherDTO instructorDto)
        {
            try
            {

                InstructorService.CreateInstructor(instructorDto);
                string responseMessage = "A six-digit OTP has been sent to your email.";
                return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }

        [HttpPost]
        [Route("api/instructor/create/{otp}")]
        public HttpResponseMessage CreateInstructorOtp(TeacherDTO instructorDTO, int otp)
        {
            TeacherDTO addedInstructor = InstructorService.CreateInstructorWithOTP(instructorDTO, otp);

            if (addedInstructor != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Instructor added successfully");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong OTP");
            }
        }

        [HttpPost]
        [Route("api/instructor/login")]
        public HttpResponseMessage Login(loginModel login)
        {
            try
            {
                var res = AuthService.Authenticate(login.Uname, login.Password);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
