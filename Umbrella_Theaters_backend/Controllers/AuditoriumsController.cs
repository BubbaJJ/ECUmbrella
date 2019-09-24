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
using System.Web.Script.Serialization;
using Umbrella_Theaters_backend.Models;

namespace Umbrella_Theaters_backend.Controllers
{
    public class AuditoriumsController : ApiController
    {
        private UmbrellaTheatersEntities db = new UmbrellaTheatersEntities();

        // GET: api/Auditoriums
        public IQueryable<Auditoriums> GetAuditoriums()
        {
            return db.Auditoriums;
        }
        //public string GetAuditoriums()
        //{
        //    var json = new JavaScriptSerializer().Serialize(db.Auditoriums);
        //    return json;
        //}

        // GET: api/Auditoriums/5
        [ResponseType(typeof(Auditoriums))]
        public string GetAuditoriums(int id)
        {
            Auditoriums auditoriums = db.Auditoriums.Find(id);
            //if (auditoriums == null)
            //{
            //    return NotFound();
            //}

            return auditoriums.AuditoriumName;
        }

        // PUT: api/Auditoriums/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuditoriums(int id, Auditoriums auditoriums)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auditoriums.AuditoriumId)
            {
                return BadRequest();
            }

            db.Entry(auditoriums).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditoriumsExists(id))
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

        // POST: api/Auditoriums
        [ResponseType(typeof(Auditoriums))]
        public IHttpActionResult PostAuditoriums(Auditoriums auditoriums)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Auditoriums.Add(auditoriums);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = auditoriums.AuditoriumId }, auditoriums);
        }

        // DELETE: api/Auditoriums/5
        [ResponseType(typeof(Auditoriums))]
        public IHttpActionResult DeleteAuditoriums(int id)
        {
            Auditoriums auditoriums = db.Auditoriums.Find(id);
            if (auditoriums == null)
            {
                return NotFound();
            }

            db.Auditoriums.Remove(auditoriums);
            db.SaveChanges();

            return Ok(auditoriums);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuditoriumsExists(int id)
        {
            return db.Auditoriums.Count(e => e.AuditoriumId == id) > 0;
        }
    }
}