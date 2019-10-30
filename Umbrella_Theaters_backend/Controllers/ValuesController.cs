using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Umbrella_Theaters_backend.Models;

namespace Umbrella_Theaters_backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authentication]
    public class ValuesController : ApiController
    {
        private UmbrellaTheatersEntities db = new UmbrellaTheatersEntities();
        // GET api/values
        public bool Get()
        {
            string userIdString = Thread.CurrentPrincipal.Identity.Name;

            return true;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
