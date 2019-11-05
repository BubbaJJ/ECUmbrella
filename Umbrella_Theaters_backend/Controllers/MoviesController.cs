using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Umbrella_Theaters_backend.Models;

namespace Umbrella_Theaters_backend.Controllers
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class MoviesController : ApiController
    {
        private UmbrellaTheatersEntities db = new UmbrellaTheatersEntities();

        // GET: api/Movies
        public ListOfMovies GetListOfMovies()
        {
            var TMDBController = new GetMovieController();
            var currentMovies = db.Movies;
            var listOfUpcomingMovies = new List<Movie>();
            var listOfCurrentMovies = new List<Movie>();

            foreach (var movie in currentMovies)
            {
                if (DateTime.Today >= movie.StartDate && DateTime.Today <= movie.EndDate)
                {
                    listOfCurrentMovies.Add(TMDBController.GetMovie(movie.TmdbId, movie.StartDate)); //
                }
                else if (DateTime.Today < movie.StartDate)
                {
                    listOfUpcomingMovies.Add(TMDBController.GetMovie(movie.TmdbId, movie.StartDate)); //
                }
            }
            foreach (var movie in listOfCurrentMovies)
            {
                movie.DbMovieId = currentMovies.Where(x => x.TmdbId == movie.Id).Select(t => t.MovieId).FirstOrDefault();
            }
            foreach (var movie in listOfUpcomingMovies)
            {
                movie.DbMovieId = currentMovies.Where(x => x.TmdbId == movie.Id).Select(t => t.MovieId).FirstOrDefault();
            }

            return new ListOfMovies
            {
                CurrentMovies = listOfCurrentMovies,
                UpcomingMovies = listOfUpcomingMovies
            };
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movies))]
        public IHttpActionResult GetMovies(int id)
        {
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovies(int id, Movies movies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movies.MovieId)
            {
                return BadRequest();
            }

            db.Entry(movies).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(Movies))]
        public IHttpActionResult PostMovies(Movies movies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movies);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movies.MovieId }, movies);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movies))]
        public IHttpActionResult DeleteMovies(int id)
        {
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movies);
            db.SaveChanges();

            return Ok(movies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MoviesExists(int id)
        {
            return db.Movies.Count(e => e.MovieId == id) > 0;
        }
    }
}