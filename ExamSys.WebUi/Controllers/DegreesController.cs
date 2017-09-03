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
    public class DegreesController : Controller
    {
        private ExamDB db = new ExamDB();

        // GET: Degrees
        public ActionResult Index()
        {
            return View(db.Degrees.ToList());
        }

        // GET: Degrees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degrees degrees = db.Degrees.Find(id);
            if (degrees == null)
            {
                return HttpNotFound();
            }
            return View(degrees);
        }

        // GET: Degrees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Title,created_at,edited_at")] Degrees degrees)
        {
            if (ModelState.IsValid)
            {
                db.Degrees.Add(degrees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(degrees);
        }

        // GET: Degrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degrees degrees = db.Degrees.Find(id);
            if (degrees == null)
            {
                return HttpNotFound();
            }
            return View(degrees);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Title,created_at,edited_at")] Degrees degrees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degrees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degrees);
        }

        // GET: Degrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degrees degrees = db.Degrees.Find(id);
            if (degrees == null)
            {
                return HttpNotFound();
            }
            return View(degrees);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Degrees degrees = db.Degrees.Find(id);
            db.Degrees.Remove(degrees);
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
