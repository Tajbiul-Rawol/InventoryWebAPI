using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace WebAPI.Controllers
{

    public class UserController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("Server time: " + DateTime.Now.ToString());
        }

        //[Authorize]
        //[HttpGet]
        //[Route("api/data/authenticate")]
        //public IHttpActionResult GetForAuthenticate()
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    return Ok("Authenticated User: " + identity.Name);
        //}

        //[Authorize(Roles="admin")]
        //[HttpGet]
        //[Route("api/data/authorized")]
        //public IHttpActionResult GetForAdmin()
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
        //    return Ok("Hello: " + identity.Name + "Role: " + string.Join(",", roles.ToList()));
        //}


        //This method is For all types of role  
        [Authorize(Roles = "superadmin, admin, user")]
        [HttpGet]
        [Route("api/data/authorized")]
        public IHttpActionResult GetValues()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            var LogTime = identity.Claims
                        .FirstOrDefault(c => c.Type == "LoggedOn").Value;
            var ID = identity.Claims.FirstOrDefault(c => c.Type == "ID").Value;
            return Ok("Hello: " + identity.Name + ", " + "ID: "+ID+
                " Your Role(s) are: " + string.Join(",", roles.ToList()) +
                "Your Login time is :" + LogTime);
        } 

    }
}
