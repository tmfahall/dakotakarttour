using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DKTFinal.Models;

namespace DKTFinal.Controllers
{
    public class DriverRacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DriverRaces
        public ActionResult Index()
        {
            return View(db.DriverRaces.ToList());
        }

        //GET: DriverRaces/Standings
        public ActionResult Standings()
        {
            var rookieTop = db.Drivers
            .Select(x => new DriverVM
            {
                Category = "Rookie",
                DriverName = x.DriverName,
                DriverNumber = x.DriverNumber,
                TotalPoints = x.DriverRaces
                .Where(y => y.Race.RaceClass == Classes.Rookie)
                .Sum(y => y.Points)
            })
            .OrderByDescending(x => x.TotalPoints)
            .Take(5);

            var adultsTop = db.Drivers
            .Select(x => new DriverVM
            {
                Category = "Adults",
                DriverName = x.DriverName,
                DriverNumber = x.DriverNumber,
                TotalPoints = x.DriverRaces
                .Where(y => y.Race.RaceClass == Classes.Adult)
                .Sum(y => y.Points)
            })
            .OrderByDescending(x => x.TotalPoints)
            .Take(5);

            var jrOneTop = db.Drivers
            .Select(x => new DriverVM
            {
                Category = "JrOne",
                DriverName = x.DriverName,
                DriverNumber = x.DriverNumber,
                TotalPoints = x.DriverRaces
                .Where(y => y.Race.RaceClass == Classes.Jr1)
                .Sum(y => y.Points)
            })
            .OrderByDescending(x => x.TotalPoints)
            .Take(5);

            var jrTwoTop = db.Drivers
            .Select(x => new DriverVM
            {
                Category = "JrTwo",
                DriverName = x.DriverName,
                DriverNumber = x.DriverNumber,
                TotalPoints = x.DriverRaces
                .Where(y => y.Race.RaceClass == Classes.Jr2)
                .Sum(y => y.Points)
            })
            .OrderByDescending(x => x.TotalPoints)
            .Take(5);

            var jrThreeTop = db.Drivers
            .Select(x => new DriverVM
            {
                Category = "JrThree",
                DriverName = x.DriverName,
                DriverNumber = x.DriverNumber,
                TotalPoints = x.DriverRaces
                .Where(y => y.Race.RaceClass == Classes.Jr3)
                .Sum(y => y.Points)
            })
            .OrderByDescending(x => x.TotalPoints)
            .Take(5);


            ViewBag.TopAdults = adultsTop.ToList();
            ViewBag.TopRookies = rookieTop.ToList();
            ViewBag.TopJrOnes = jrOneTop.ToList();
            ViewBag.TopJrTwos = jrTwoTop.ToList();
            ViewBag.TopJrThrees = jrThreeTop.ToList();

            return View();
        }

        // GET: DriverRaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverRace driverRace = db.DriverRaces.Find(id);
            if (driverRace == null)
            {
                return HttpNotFound();
            }
            return View(driverRace);
        }

        // GET: DriverRaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriverRaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverRaceID,Points,Driver_DriverID,Race_RaceID")] DriverRace driverRace)
        {
            if (ModelState.IsValid)
            {
                db.DriverRaces.Add(driverRace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driverRace);
        }

        // GET: DriverRaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverRace driverRace = db.DriverRaces.Find(id);
            if (driverRace == null)
            {
                return HttpNotFound();
            }
            return View(driverRace);
        }

        // POST: DriverRaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverRaceID,Points,Driver_DriverID,Race_RaceID")] DriverRace driverRace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverRace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverRace);
        }

        // GET: DriverRaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverRace driverRace = db.DriverRaces.Find(id);
            if (driverRace == null)
            {
                return HttpNotFound();
            }
            return View(driverRace);
        }

        // POST: DriverRaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriverRace driverRace = db.DriverRaces.Find(id);
            db.DriverRaces.Remove(driverRace);
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
