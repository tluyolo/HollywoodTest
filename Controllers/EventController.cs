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
    public class EventController : Controller
    {
        private HollywoodTestEntities1 db = new HollywoodTestEntities1();

        // GET: Event
        public ActionResult Index()
        {
            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();


            List<Event> events = Entities.Events.ToList();

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



        // GET: Event/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }
        public ActionResult Display()
        {
            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();
            List<Event> events = Entities.Events.ToList();
            return View(events.ToList());
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            ViewBag.TounamentID = new SelectList(db.Tournaments, "TounamentID", "TournamentName");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,TounamentID,EventName,EventNumber,EventDateTime,EventEndDateTime,AutoClose")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TounamentID = new SelectList(db.Tournaments, "TounamentID", "TournamentName", @event.TounamentID);
            return View(@event);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.TounamentID = new SelectList(db.Tournaments, "TounamentID", "TournamentName", @event.TounamentID);
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,TounamentID,EventName,EventNumber,EventDateTime,EventEndDateTime,AutoClose")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TounamentID = new SelectList(db.Tournaments, "TounamentID", "TournamentName", @event.TounamentID);
            return View(@event);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
