using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Umbrella_Theaters_backend.Models;

namespace Umbrella_Theaters_backend.Controllers
{
    
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class BookingController : ApiController
    {
        private UmbrellaTheatersEntities db = new UmbrellaTheatersEntities();
        [Authentication]
        // GET: api/Booking
        public List<UserBookings> Get()
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;
            var user = db.Users.Where(x => x.Email == userName).FirstOrDefault();
            var dbListOfBookingsByEmail = db.Bookings.Where(x => x.Email == user.Email).ToList();
            var dbListOfUserBookings = db.Bookings.Where(x => x.BookedById == user.UserId).ToList();
            
            foreach (var movieBooking in dbListOfBookingsByEmail)
            {
                if (!dbListOfUserBookings.Contains(movieBooking))
                dbListOfUserBookings.Add(movieBooking);
            }

                var _getMovieController = new GetMovieController();

            var userBookings = new List<UserBookings>();

            foreach (var booking in dbListOfUserBookings)
            {
                var movie = db.Screenings.Where(x => x.ScreeningId == booking.ScreeningId).FirstOrDefault().MovieId;
                var tmdbMovieId = db.Movies.Where(x => x.MovieId == movie).FirstOrDefault().TmdbId;

                var tmdbMovie = _getMovieController.GetMovie(tmdbMovieId);
                userBookings.Add(new UserBookings
                {
                    PosterPath = tmdbMovie.PosterPath,
                    MovieName = tmdbMovie.MovieName,
                    BookingId = booking.BookingId,
                    Paid = booking.Paid,
                    ScreeningId = booking.ScreeningId,
                    SeatId = booking.SeatId
                });
            }

             return userBookings;
        }

        // GET: api/Booking/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(db.Bookings.Find(id));
            } 
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Booking
        public IHttpActionResult Post([FromBody]Bookings request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bookings.Add(request);
            db.SaveChanges();

            return Ok();
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
