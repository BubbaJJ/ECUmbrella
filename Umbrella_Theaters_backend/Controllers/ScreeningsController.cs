using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Umbrella_Theaters_backend.Models;

namespace Umbrella_Theaters_backend.Controllers
{
    public class ScreeningsController : ApiController
    {
        private UmbrellaTheatersEntities db = new UmbrellaTheatersEntities();

        // GET: api/Screenings
        public IQueryable<Screenings> GetScreenings()
        {
            return db.Screenings;
        }

        // GET: api/Screenings/5
        [ResponseType(typeof(Screenings))]
        public IHttpActionResult GetScreenings(int id)
        {
            Screenings screenings = db.Screenings.Find(id);
            if (screenings == null)
            {
                return NotFound();
            }

            return Ok(screenings);
        }

        // PUT: api/Screenings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutScreenings(int id, Screenings screenings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != screenings.ScreeningId)
            {
                return BadRequest();
            }

            db.Entry(screenings).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScreeningsExists(id))
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

        // POST: api/Screenings
        [ResponseType(typeof(Screenings))]
        public IHttpActionResult PostScreenings(Screenings screenings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Screenings.Add(screenings);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = screenings.ScreeningId }, screenings);
        }

        // DELETE: api/Screenings/5
        [ResponseType(typeof(Screenings))]
        public IHttpActionResult DeleteScreenings(int id)
        {
            Screenings screenings = db.Screenings.Find(id);
            if (screenings == null)
            {
                return NotFound();
            }

            db.Screenings.Remove(screenings);
            db.SaveChanges();

            return Ok(screenings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScreeningsExists(int id)
        {
            return db.Screenings.Count(e => e.ScreeningId == id) > 0;
        }
    }
}