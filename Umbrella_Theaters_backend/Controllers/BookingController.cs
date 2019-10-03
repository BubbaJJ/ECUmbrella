using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Umbrella_Theaters_backend.Models;

namespace Umbrella_Theaters_backend.Controllers
{
    public class BookingController : ApiController
    {
        private UmbrellaTheatersEntities db = new UmbrellaTheatersEntities();

        // GET: api/Booking
        public IEnumerable<Bookings> Get()
        {
            return db.Bookings;
        }

        // GET: api/Booking/5
        public IHttpActionResult Get(int id)
        {
            Bookings booking = db.Bookings.Find(id);

            if (booking == null)
            {
                return BadRequest();
            }

            return Ok(booking);
        }

        // POST: api/Booking
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Booking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Booking/5
        public void Delete(int id)
        {
        }
    }
}
