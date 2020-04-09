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
using System.Web.Mvc;
using HollywoodTest;

namespace HollywoodTest.Controllers.Api
{
    public class EventDetailsController : ApiController
    {
        private HollywoodTestEntities1 db = new HollywoodTestEntities1();

        // GET: api/EventDetails
        public IQueryable<EventDetail> GetEventDetails()
        {
            return db.EventDetails;
        }

        // GET: api/EventDetails/5
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult GetEventDetail(long id)
        {
            EventDetail eventDetail = db.EventDetails.Find(id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            return Ok(eventDetail);
        }

        // PUT: api/EventDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventDetail(long id, EventDetail eventDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventDetail.EventDetailID)
            {
                return BadRequest();
            }

            db.Entry(eventDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventDetailExists(id))
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

        // POST: api/EventDetails
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult PostEventDetail(EventDetail eventDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.EventDetails.Add(eventDetail);
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EventDetailExists(eventDetail.EventDetailID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eventDetail.EventDetailID }, eventDetail);
        }




        // DELETE: api/EventDetails/DeleteEventDetail
        [System.Web.Mvc.Route("api/EventDetails/DeleteEventDetail")]
       [System.Web.Mvc.HttpPost]
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult DeleteEventDetail(EventDetail _eventDetail)
        {
       
            using (HollywoodTestEntities1 db = new HollywoodTestEntities1()) 
            {
                int eventN = Convert.ToInt32(_eventDetail.EventDetailID);
                EventDetail eventdetail = (from ev in db.EventDetails where ev.EventDetailID == _eventDetail.EventDetailID select ev).FirstOrDefault();
                db.EventDetails.Remove(eventdetail);
                db.SaveChanges();
            }
            return Ok("");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventDetailExists(long id)
        {
            return db.EventDetails.Count(e => e.EventDetailID == id) > 0;
        }
    }
}