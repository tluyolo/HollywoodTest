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
using HollywoodTest;

namespace HollywoodTest.Controllers.Api
{
    public class EventController : ApiController
    {
        private HollywoodTestEntities1 db = new HollywoodTestEntities1();

        // GET: api/Event
        public IQueryable<Event> GetEvents()
        {
            return db.Events;
        }

        // GET: api/Event/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent()
        {
            List<Event> events =null;
            using (var entities = new HollywoodTestEntities1())
            {

                events = entities.Events.Select(Ev => new Event()
                {
                    EventID = Ev.EventID,
                    TounamentID = Ev.TounamentID,
                    EventName = Ev.EventName,
                    EventNumber = Ev.EventNumber,
                    EventDateTime = Ev.EventDateTime,
                    EventEndDateTime = Ev.EventEndDateTime,
                    AutoClose = Ev.AutoClose

                }).ToList<Event>();

                if (events == null)
                {
                    return NotFound();
                }

                return Ok(events);
            }
        }
        public void index()
        {
            List<Event> events = null;
            using (var entities = new HollywoodTestEntities1())
            {

                events = entities.Events.Select(Ev => new Event()
                {
                    EventID = Ev.EventID,
                    TounamentID = Ev.TounamentID,
                    EventName = Ev.EventName,
                    EventNumber = Ev.EventNumber,
                    EventDateTime = Ev.EventDateTime,
                    EventEndDateTime = Ev.EventEndDateTime,
                    AutoClose = Ev.AutoClose

                }).ToList<Event>();

              

            
        }
        }
        // PUT: api/Event/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvent(long id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.EventID)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Event
        [ResponseType(typeof(Event))]
        public IHttpActionResult PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(@event);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EventExists(@event.EventID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = @event.EventID }, @event);
        }

        // DELETE: api/Event/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(long id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            db.SaveChanges();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(long id)
        {
            return db.Events.Count(e => e.EventID == id) > 0;
        }
    }
}