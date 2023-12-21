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
    }
}
