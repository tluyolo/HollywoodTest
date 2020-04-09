using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using HollywoodTest;

namespace HollywoodTest.Controllers
{
    public class EventDetailsController : Controller
    {
        private HollywoodTestEntities1 db = new HollywoodTestEntities1();

        // GET: EventDetails
        public ActionResult Index()
        {

            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();


            List<EventDetail> events = Entities.EventDetails.ToList();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/Api/index");
                var responseTask = client.GetAsync("Events");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readEve = result.Content.ReadAsAsync<IList<Event>>();
                    readEve.Wait();

                    // events = readEve.Result;
                }
                else
                {
                    //events = Enumerable.Empty<Event>();
                    ModelState.AddModelError(String.Empty, "Server error. Please Contact administrator");
                }
            }
            return View(events.ToList());
        }


        public ActionResult Display()
        {

            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();
            List<EventDetail> events = Entities.EventDetails.ToList();
            return View(events.ToList());
        }

        public ActionResult Update()
        {

            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();
            List<EventDetail> events = Entities.EventDetails.ToList();
            return View(events.ToList());
        }


        // GET: EventDetails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetail eventDetail = db.EventDetails.Find(id);
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventDetail);
        }

        // GET: EventDetails/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            return View();
        }

        // POST: EventDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventDetailID,EventID,EventDetailStatusID,EventDetailName,EventDetailNumber,EventDetailOdd,FinishingPosition,FirsTimer")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                db.EventDetails.Add(eventDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventDetail.EventID);
            return View(eventDetail);
        }

        // GET: EventDetails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetail eventDetail = db.EventDetails.Find(id);
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventDetail.EventID);
            return View(eventDetail);
        }

        // POST: EventDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventDetailID,EventID,EventDetailStatusID,EventDetailName,EventDetailNumber,EventDetailOdd,FinishingPosition,FirsTimer")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventDetail.EventID);
            return View(eventDetail);
        }

        // GET: EventDetails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetail eventDetail = db.EventDetails.Find(id);
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventDetail);
        }
        public ActionResult DeleteEvent(int[] EventIDs)
        {
            try
            {

                using (HollywoodTestEntities1 entities = new HollywoodTestEntities1())
                {
                    foreach (int EventId in EventIDs)
                    {
                        EventDetail events = (from Ev in entities.EventDetails where Ev.EventDetailID == EventId select Ev).FirstOrDefault();
                        entities.EventDetails.Remove(events);
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

        // POST: EventDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            EventDetail eventDetail = db.EventDetails.Find(id);
            db.EventDetails.Remove(eventDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
