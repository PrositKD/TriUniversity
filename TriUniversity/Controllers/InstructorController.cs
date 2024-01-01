using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace TriUniversity.Controllers
{
    public class InstructorController : ApiController
    {

        [HttpPost]
        [Route("api/instructor/create")]
        public HttpResponseMessage CreateInstructor(TeacherDTO instructorDto)
        {
            try
            {

                InstructorService.CreateInstructor(instructorDto);
                string responseMessage = "A six-digit OTP has been sent to your email.";
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = responseMessage });
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
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Instructor added successfully" });
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
        [HttpPost]
        [Route("api/instructor/forgetpss")]
        public HttpResponseMessage forgetpss()
        {
            var httpRequest = HttpContext.Current.Request;
            try
            {
                string email = httpRequest.Form["email"];
                var res = AuthService.AuthenticateWithoutToken(email);
                if (res != false)
                {
                    AuthService.forgetpassOtp(email);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = " 6 digit otp has been sent" });

                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Email not found" });
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message }); }
        }

        [HttpPost]
        [Route("api/instructor/forgetpssUpdate")]
        public HttpResponseMessage passUpdate()
        {
            var httpRequest = HttpContext.Current.Request;
            string otp = httpRequest.Form["otp"];
            string pass = httpRequest.Form["pass"];
            string email = httpRequest.Form["email"];
            try
            {


                var res = AuthService.checkOtp(otp, pass, email);
                if (res != false)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = " Password updated successfully" });

                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "OTP is not matched" });
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message }); }
        }

        [HttpGet]
        [Route("api/logout/{token}")]
        public HttpResponseMessage logout(logoutModel logout, string token)
        {
            try
            {
                var res = AuthService.AuthenticateWithoutToken(logout.Uname);

                if (res != false)
                {
                    var userId = CourseService.CreateCourse(token);
                    if (userId != null)
                    {
                        var successLogOut = AuthService.logout(userId);

                        if (successLogOut != null)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "You have been logout successfully!" });
                        }

                        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Logout Failed" });
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Invalid Token" });
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.ToString());
            }

        }


        [HttpPost]
        [Route("api/instructor/course/upload/{token}")]
        public async Task<HttpResponseMessage> coursecreating(string token)
        {
            try
            {
                var res = CourseService.CreateCourse(token);
                if (res != null)
                {

                    var httpRequest = HttpContext.Current.Request;


                    if (httpRequest.Files.Count > 0)
                    {

                        string uploadedFileName = string.Empty;
                        foreach (string file in httpRequest.Files)
                        {
                            var postedFile = httpRequest.Files[file];
                            var filePath = HttpContext.Current.Server.MapPath("~/App_Data/" + postedFile.FileName);
                            await Task.Run(() => postedFile.SaveAs(filePath));
                            uploadedFileName = postedFile.FileName;
                        }
                        string name = httpRequest.Form["Name"];
                        string shortDescription = httpRequest.Form["ShortDescription"];
                        string duration = httpRequest.Form["Duration"];
                        string instructorName = httpRequest.Form["InstructorName"];
                        string price = httpRequest.Form["Price"];

                        CourseDTO courseDTO = new CourseDTO
                        {
                            Name = name,
                            ShortDescription = shortDescription,
                            Duration = duration,
                            InstructorName = instructorName,
                            Price = price
                            // Add other properties as needed
                        };

                        var courseSuccess = CourseService.CreateCourseSure(courseDTO, uploadedFileName, res);
                        if (courseSuccess != null)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Course uploaded successfully!" });
                        }

                        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Course is not uploaded." });
                    }
                    else
                    {

                        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "No files were uploaded." });
                    }
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Token is not valid" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/instructor/{courseId}/monthlyEarning/{token}")]
        public HttpResponseMessage monthSpeceficEarning(string token, int courseId)
        {
            try
            {
                var res = CourseService.CreateCourse(token);
                if (res != null)
                {
                    int realCourseId = CourseService.findCoursIdd(courseId);
                    if (realCourseId != 0)
                    {
                        if (courseId == realCourseId)
                        {
                            var data = CourseService.earning(realCourseId);
                            if (data != null)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, data);
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Failed to fetch earnings" });
                            }
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Course Id is not valid" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Token is not valid" });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
    }
}
