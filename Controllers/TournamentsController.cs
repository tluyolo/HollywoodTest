using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using HollywoodTest;

namespace HollywoodTest.Controllers
{
    public class TournamentsController : Controller
    {
        private HollywoodTestEntities1 db = new HollywoodTestEntities1();

        // GET: Tournaments
        public ActionResult Index()
        {
            //HollywoodTestEntities1 Entities = new HollywoodTestEntities1();
            ViewBag.ListTournament = this.db.Tournaments.ToList();
           // List<Tournament> events = Entities.Tournaments.ToList();
            return View();
        }

        public ActionResult IndexUpdate()
        {
            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();
            List<Tournament> events = Entities.Tournaments.ToList();
            return View(events.ToList());
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            try
            {
                string[] TounamentIDs = formCollection["TounamentID"].Split(new char[] { ',' });
                foreach (string TounamentID in TounamentIDs)
                {
                    var tournament = this.db.Tournaments.Find(int.Parse(TounamentID));
                    this.db.Tournaments.Remove(tournament);
                    this.db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ListTournament = this.db.Tournaments.ToList();
                return View();
            }
        }

        public ActionResult Update()
        {
            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();
            List<Tournament> events = Entities.Tournaments.ToList();
            return View(events.ToList());
        }


        public ActionResult Display()
        {
            HollywoodTestEntities1 Entities = new HollywoodTestEntities1();
            List<Tournament> events = Entities.Tournaments.ToList();
            return View(events.ToList());
        }



        // GET: Tournaments/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }
        public JsonResult ListTounament()
        {
            //return Json(db.tournament.ToList(), JsonRequestBehavior.AllowGet);
            return Json(from obj in db.Tournaments select new { TournamentID = obj.TounamentID, TournmentName = obj.TournamentName }, JsonRequestBehavior.AllowGet);
        }

        // GET: Tournaments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tournament
        [HttpPost]
        public string CreateTournament(Tournament tournament)
        {
            if (!ModelState.IsValid) return "Model is invalid";
            db.Tournaments.Add(tournament);
            db.SaveChanges();
            return "Tourname is created";
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TounamentID,TournamentName")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Tournaments.Add(tournament);
                db.SaveChanges();
               return RedirectToAction("Index");
              
            }

            return View(tournament);
        }

        // GET: Tournaments/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
              
            }
            return View(tournament);
        }



        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TounamentID,TournamentName")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tournament);
        }

        // POST: Employee/Update/5
        [HttpPost]
        public string Update(Tournament tournament)
        {
            if (!ModelState.IsValid) return "Invalid model";
            db.Entry(tournament).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated successfully";

        }
            // GET: Tournaments/Delete/5

        public ActionResult DeleteEvent(int[] EventIDs)
        {
            try
            {

                using (HollywoodTestEntities1 entities = new HollywoodTestEntities1())
                {
                    foreach (int EventId in EventIDs)
                    {
                        Tournament events = (from Ev in entities.Tournaments where Ev.TounamentID == EventId select Ev).FirstOrDefault();
                        entities.Tournaments.Remove(events);
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

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tournament tournament = db.Tournaments.Find(id);
            db.Tournaments.Remove(tournament);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public string Delete(Tournament tournament)
        {
            if (tournament == null) return "Invalid data";
            var getTournament = db.Tournaments.Find(tournament.TounamentID);
            db.Tournaments.Remove(getTournament);
            db.SaveChanges();
            return "Deleted successfully";
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
