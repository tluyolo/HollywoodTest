using HollywoodTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HollywoodTest.Controllers
{
    public class EventDetailStatusController : Controller
    {
        HollywoodTestEntities1 db = new HollywoodTestEntities1();
        // GET: EventDetailStatus
        public ActionResult Index()
        {

            ViewBag.ListStatus = this.db.EventDetailStatus.ToList();
            return View();
        }

        public ActionResult IndexUpdate()
        {
            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();
            List<EventDetailStatu> events = Entities.EventDetailStatus.ToList();
            return View(events.ToList());
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            try
            {
                string[] EventDetailStatusIDs = formCollection["EventDetailStatusID"].Split(new char[] { ',' });
                foreach (string EventDetailStatusID in EventDetailStatusIDs)
                {
                    var eventDetailStatus = this.db.EventDetailStatus.Find(int.Parse(EventDetailStatusID));
                    this.db.EventDetailStatus.Remove(eventDetailStatus);
                    this.db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ListStatus = this.db.EventDetailStatus.ToList();
                return View();
            }
        }
            public ActionResult Display()
        {
            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();
            List<EventDetailStatu> events = Entities.EventDetailStatus.ToList();
            return View(events.ToList());
        }



        // GET: EventDetailStatus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventDetailStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventDetailStatus/Create
        [HttpPost]
        public ActionResult Create(EventDetailStatusModels Emodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EventDetailStatus sdb = new EventDetailStatus();
                    if (sdb.AddEventDetailStatus(Emodel))
                    {
                        ViewBag.Message = "Event Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    

        // GET: EventDetailStatus/Edit/5
        public ActionResult Edit(short? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetailStatu @event = db.EventDetailStatus.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
          return View(@event);
        }

        // POST: EventDetailStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventDetailStatusID,EventDetailStatusName")] EventDetailStatus @event)
        {
            try
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EventDetailStatus/Delete/5
        public ActionResult Delete(int EventDStatusid)
        {
            try
            {
                EventDetailStatus sdb = new EventDetailStatus();
                if (sdb.DeleteEventDetailstatus(EventDStatusid))
                {
                    ViewBag.AlertMsg = "Event Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteEvent(int[] EventIDs)
        {
            try
            {

                using (HollywoodTestEntities1 entities = new HollywoodTestEntities1())
                {
                    foreach (int EventId in EventIDs)
                    {
                        EventDetailStatu events = (from Ev in entities.EventDetailStatus where Ev.EventDetailStatusID == EventId select Ev).FirstOrDefault();
                        entities.EventDetailStatus.Remove(events);
                    }
                    entities.SaveChanges();
                }
                return new EmptyResult();
            }
            catch
            {
                return View();
            }
        }

    }
}
