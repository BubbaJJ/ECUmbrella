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
    public class TheatersController : ApiController
    {
        private UmbrellaTheatersEntities db = new UmbrellaTheatersEntities();

        // GET: api/Theaters
        public IQueryable<Theaters> GetTheaters()
        {
            return db.Theaters;
        }

        // GET: api/Theaters/5
        [ResponseType(typeof(Theaters))]
        public IHttpActionResult GetTheaters(int id)
        {
            Theaters theaters = db.Theaters.Find(id);
            if (theaters == null)
            {
                return NotFound();
            }

            return Ok(theaters);
        }

        // PUT: api/Theaters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTheaters(int id, Theaters theaters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != theaters.TheaterId)
            {
                return BadRequest();
            }

            db.Entry(theaters).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheatersExists(id))
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

        // POST: api/Theaters
        [ResponseType(typeof(Theaters))]
        public IHttpActionResult PostTheaters(Theaters theaters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Theaters.Add(theaters);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = theaters.TheaterId }, theaters);
        }

        // DELETE: api/Theaters/5
        [ResponseType(typeof(Theaters))]
        public IHttpActionResult DeleteTheaters(int id)
        {
            Theaters theaters = db.Theaters.Find(id);
            if (theaters == null)
            {
                return NotFound();
            }

            db.Theaters.Remove(theaters);
            db.SaveChanges();

            return Ok(theaters);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TheatersExists(int id)
        {
            return db.Theaters.Count(e => e.TheaterId == id) > 0;
        }
    }
}