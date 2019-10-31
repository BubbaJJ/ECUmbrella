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
        [Authentication(false)]
        // GET: api/Booking
        public List<UserTicket> Get()
        {
            var _getMovieController = new GetMovieController();

            var user = db.Users.Find(Convert.ToInt32(Thread.CurrentPrincipal.Identity.Name));
            var dbListOfBookingsByEmail = db.Bookings.Where(x => x.Email == user.Email).ToList();
            var screenings = dbListOfBookingsByEmail.Select(x => x.ScreeningId).Distinct().ToList();

            var listOfScreenings = new List<UserTicket>();
            foreach (var screening in screenings)
            {
                var movie = db.Screenings.Where(x => x.ScreeningId == screening).FirstOrDefault();
                var tmdbMovieId = db.Movies.Where(x => x.MovieId == movie.MovieId).FirstOrDefault().TmdbId;
                var tmdbMovie = _getMovieController.GetMovie(tmdbMovieId);
                listOfScreenings.Add(new UserTicket
                {
                    ScreeningId = screening,
                    PosterPath = tmdbMovie.PosterPath,
                    MovieName = tmdbMovie.MovieName,
                    ViewingDate = movie.ViewingDate,
                    StartTime = movie.StartTime,
                    AuditoriumId = movie.AuditoriumId,
                    NumberOfTickets = dbListOfBookingsByEmail.Where(x => x.ScreeningId == screening).Count()
                });
            }
            return listOfScreenings;

            //var listretur = new List<List<UserTicket>>();
            //foreach (var screening in screenings)
            //{
            //    var movie = db.Screenings.Where(x => x.ScreeningId == screening).FirstOrDefault();
            //    var tmdbMovieId = db.Movies.Where(x => x.MovieId == movie.MovieId).FirstOrDefault().TmdbId;
            //    var tmdbMovie = _getMovieController.GetMovie(tmdbMovieId);

            //    var userTickets = new List<UserTicket>();
            //    foreach (var booking in dbListOfBookingsByEmail)
            //    {
            //        if (booking.ScreeningId == screening)
            //        {
            //            userTickets.Add(new UserTicket
            //            {
            //                PosterPath = tmdbMovie.PosterPath,
            //                MovieName = tmdbMovie.MovieName,
            //                BookingId = booking.BookingId,
            //                Paid = booking.Paid,
            //                ScreeningId = booking.ScreeningId,
            //                SeatId = booking.SeatId,
            //                ViewingDate = movie.ViewingDate,
            //                StartTime = movie.StartTime,
            //                AuditoriumId = movie.AuditoriumId
            //            });
            //        }
            //    }
            //    listretur.Add(userTickets);
            //}
            //return listretur;
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
        public IHttpActionResult Post([FromBody]BookTicketsRequest request)
        {
            var listOfTickets = new List<Bookings>();
            var seatStartNumber = db.Bookings.Where(x => x.ScreeningId == request.ScreeningId).ToList().OrderByDescending(o => o.SeatId);
            var listOfSeatsBooked = seatStartNumber.Select(x => x.SeatId).ToList();
            int seat = listOfSeatsBooked.FirstOrDefault() + 1;
            for (int i = 1; i <= request.NumberOfTickets; i++)
            {

                listOfTickets.Add(new Bookings
                {
                    BookedById = request.BookedById,
                    Email = request.Email,
                    Paid = request.Paid,
                    ScreeningId = request.ScreeningId,
                    SeatId = seat
                });
                //}
                seat += 1;

                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}


            }
            foreach (var ticketBooking in listOfTickets)
            {
                db.Bookings.Add(ticketBooking);
            }


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
