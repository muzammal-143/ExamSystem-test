﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamSys.Database;
using ExamSys.Database.dbEntities;

namespace ExamSys.WebUi.Controllers
{
    public class DesignationsController : Controller
    {
        private ExamDB db = new ExamDB();

        // GET: Designations
        public ActionResult Index()
        {
            return View(db.Designations.ToList());
        }

        // GET: Designations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designations designations = db.Designations.Find(id);
            if (designations == null)
            {
                return HttpNotFound();
            }
            return View(designations);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Title,created_at,edited_at")] Designations designations)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(designations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designations);
        }

        // GET: Designations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designations designations = db.Designations.Find(id);
            if (designations == null)
            {
                return HttpNotFound();
            }
            return View(designations);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Title,created_at,edited_at")] Designations designations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designations);
        }

        // GET: Designations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designations designations = db.Designations.Find(id);
            if (designations == null)
            {
                return HttpNotFound();
            }
            return View(designations);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designations designations = db.Designations.Find(id);
            db.Designations.Remove(designations);
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
