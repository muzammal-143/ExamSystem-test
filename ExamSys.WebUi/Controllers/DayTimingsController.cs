using System;
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
    public class DayTimingsController : Controller
    {
        private ExamDB db = new ExamDB();

        // GET: DayTimings
        public ActionResult Index()
        {
            return View(db.DayTiming.ToList());
        }

        // GET: DayTimings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayTiming dayTiming = db.DayTiming.Find(id);
            if (dayTiming == null)
            {
                return HttpNotFound();
            }
            return View(dayTiming);
        }

        // GET: DayTimings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DayTimings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Timing,created_at,edited_at")] DayTiming dayTiming)
        {
            if (ModelState.IsValid)
            {
                db.DayTiming.Add(dayTiming);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dayTiming);
        }

        // GET: DayTimings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayTiming dayTiming = db.DayTiming.Find(id);
            if (dayTiming == null)
            {
                return HttpNotFound();
            }
            return View(dayTiming);
        }

        // POST: DayTimings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Timing,created_at,edited_at")] DayTiming dayTiming)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dayTiming).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dayTiming);
        }

        // GET: DayTimings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayTiming dayTiming = db.DayTiming.Find(id);
            if (dayTiming == null)
            {
                return HttpNotFound();
            }
            return View(dayTiming);
        }

        // POST: DayTimings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DayTiming dayTiming = db.DayTiming.Find(id);
            db.DayTiming.Remove(dayTiming);
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
