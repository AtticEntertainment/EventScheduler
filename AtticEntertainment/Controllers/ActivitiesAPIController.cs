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
using AtticEntertainment.Models;

namespace AtticEntertainment.Controllers
{
    public class ActivitiesAPIController : ApiController
    {
        private AtticEntertainmentContext db = new AtticEntertainmentContext();

        // GET: api/ActivitiesAPI
        public IEnumerable<Activity> GetActivities()
        {
            return db.Activities.ToList();
        }

        // GET: api/ActivitiesAPI/5
        [ResponseType(typeof(Activity))]
        public IHttpActionResult GetActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // PUT: api/ActivitiesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivity(int id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.ActivityId)
            {
                return BadRequest();
            }

            db.Entry(activity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
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

        // POST: api/ActivitiesAPI/{Room Id}
        [ResponseType(typeof(Activity))]
        public IHttpActionResult PostActivity(int id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Room r = db.Rooms.Find(id);

            //db.Activities.Add(activity);

            r.RoomActivities.Add(activity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = activity.ActivityId }, activity);
        }

        // DELETE: api/ActivitiesAPI/5
        [ResponseType(typeof(Activity))]
        public IHttpActionResult DeleteActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            db.Activities.Remove(activity);
            db.SaveChanges();

            return Ok(activity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityExists(int id)
        {
            return db.Activities.Count(e => e.ActivityId == id) > 0;
        }
    }
}