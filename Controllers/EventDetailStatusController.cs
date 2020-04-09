using HollywoodTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HollywoodTest.Controllers
{
    public class EventDetailStatusController : Controller
    {
        // GET: EventDetailStatus
        public ActionResult Index()
        {
            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();
            List<EventDetailStatu> events = Entities.EventDetailStatus.ToList();
            return View(events.ToList());
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
        public ActionResult Edit(int Eventid)
        {
        EventDetailStatus sdb = new EventDetailStatus();
        return View(sdb.GetEventDetailstatus().Find(Emodel => Emodel.EventDetailstatusID == Eventid));
    }

        // POST: EventDetailStatus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventDetailStatusModels Emodel)
        {
            try
            {
                EventDetailStatus sdb = new EventDetailStatus();
                sdb.UpdateDetails(Emodel);
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
