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
        [Authentication]
        public IHttpActionResult login()
        {
            string userIdString = Thread.CurrentPrincipal.Identity.Name;
            int userId = Convert.ToInt32(userIdString);

            string userFirstName = db.Users.Find(userId).FirstName;

            return Ok("Wellcome " + userFirstName + "!");
        }
    }
}
