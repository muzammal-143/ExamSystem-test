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
    public class Result_TypesController : Controller
    {
        private ExamDB db = new ExamDB();

        // GET: Result_Types
        public ActionResult Index()
        {
            return View(db.Result_Types.ToList());
        }

        // GET: Result_Types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result_Types result_Types = db.Result_Types.Find(id);
            if (result_Types == null)
            {
                return HttpNotFound();
            }
            return View(result_Types);
        }

        // GET: Result_Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Result_Types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Type,created_at,edited_at")] Result_Types result_Types)
        {
            if (ModelState.IsValid)
            {
                db.Result_Types.Add(result_Types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(result_Types);
        }

        // GET: Result_Types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result_Types result_Types = db.Result_Types.Find(id);
            if (result_Types == null)
            {
                return HttpNotFound();
            }
            return View(result_Types);
        }

        // POST: Result_Types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Type,created_at,edited_at")] Result_Types result_Types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result_Types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(result_Types);
        }

        // GET: Result_Types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result_Types result_Types = db.Result_Types.Find(id);
            if (result_Types == null)
            {
                return HttpNotFound();
            }
            return View(result_Types);
        }

        // POST: Result_Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Result_Types result_Types = db.Result_Types.Find(id);
            db.Result_Types.Remove(result_Types);
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
