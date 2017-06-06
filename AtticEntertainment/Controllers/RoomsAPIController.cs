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
    public class RoomsAPIController : ApiController
    {
        private AtticEntertainmentContext db = new AtticEntertainmentContext();

        // GET: api/RoomsAPI
        public IEnumerable<Room> GetRooms()
        {
            return db.Rooms.ToList();
        }

        // GET: api/RoomsAPI/5
        [ResponseType(typeof(Room))]
        public IHttpActionResult GetRoom(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // PUT: api/RoomsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoom(int id, Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room.RoomId)
            {
                return BadRequest();
            }

            db.Entry(room).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/RoomsAPI
        [ResponseType(typeof(Room))]
        public IHttpActionResult PostRoom(Room room, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Event e = db.Events.Find(id);
            e.EventRooms.Add(room);

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = room.RoomId }, room);
        }

        // DELETE: api/RoomsAPI/5
        [ResponseType(typeof(Room))]
        public IHttpActionResult DeleteRoom(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            room.RoomActivities.Clear();
            db.Rooms.Remove(room);
            db.SaveChanges();

            return Ok(room);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomExists(int id)
        {
            return db.Rooms.Count(e => e.RoomId == id) > 0;
        }
    }
}