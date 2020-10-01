using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using Umbrella_Theaters_backend.Models;

namespace Umbrella_Theaters_backend.Controllers
{
    public class AuthenticationController : ApiController
    {
        private UmbrellaTheatersEntities db = new UmbrellaTheatersEntities();

        // GET api/login
        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("api/login")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authentication(false)]
        public IHttpActionResult login()
        {
            int userId = Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name);
            var user = db.Users.Find(userId);

            var userToSendBack = new UserDto
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                IsAdmin = user.Admin
            };
            return Ok(userToSendBack);
        }
    }
}
