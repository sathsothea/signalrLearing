using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace APISample.Controllers
{
    public class DataController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/accessall")]
        public IHttpActionResult Get()
        {
            return Ok(new User[]
            {
                new User { Id = 1, Name = "Sophal" },
                new User { Id = 2, Name = "Sothea" },
                new User { Id = 3, Name = "Manith" },
            });
        }

        [HttpGet]
        [Authorize]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok($"Username is {identity.Name}");
        }

        [HttpGet]
        [Authorize("admin")]
        [Route("api/data/admin")]
        public IHttpActionResult GetAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok($"Hello {identity.Name}");
        }
    }
}
