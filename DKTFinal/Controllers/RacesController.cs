﻿using System;
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
    public class RacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Races
        public ActionResult Index()
        {
            return View(db.Races.ToList());
        }

        // GET: Races/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // GET: Races/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Races/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaceID,RaceDate,RaceName,RaceClass")] Race race)
        {
            if (ModelState.IsValid)
            {
                db.Races.Add(race);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(race);
        }

        // GET: Races/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // POST: Races/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaceID,RaceDate,RaceName,RaceClass")] Race race)
        {
            if (ModelState.IsValid)
            {
                db.Entry(race).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(race);
        }

        // GET: Races/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = db.Races.Find(id);
            db.Races.Remove(race);
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
