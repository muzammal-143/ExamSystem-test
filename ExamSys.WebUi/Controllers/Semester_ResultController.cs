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
    public class Semester_ResultController : Controller
    {
        private ExamDB db = new ExamDB();

        // GET: Semester_Result
        public ActionResult Index()
        {
            return View(db.Semester_Result.ToList());
        }

        // GET: Semester_Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Result semester_Result = db.Semester_Result.Find(id);
            if (semester_Result == null)
            {
                return HttpNotFound();
            }
            return View(semester_Result);
        }

        // GET: Semester_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semester_Result/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Semester,TM,OM,GP,LG,Student,Department,Faculty,Course,created_at,edited_at")] Semester_Result semester_Result)
        {
            if (ModelState.IsValid)
            {
                db.Semester_Result.Add(semester_Result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semester_Result);
        }

        // GET: Semester_Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Result semester_Result = db.Semester_Result.Find(id);
            if (semester_Result == null)
            {
                return HttpNotFound();
            }
            return View(semester_Result);
        }

        // POST: Semester_Result/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Semester,TM,OM,GP,LG,Student,Department,Faculty,Course,created_at,edited_at")] Semester_Result semester_Result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semester_Result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semester_Result);
        }

        // GET: Semester_Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Result semester_Result = db.Semester_Result.Find(id);
            if (semester_Result == null)
            {
                return HttpNotFound();
            }
            return View(semester_Result);
        }

        // POST: Semester_Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semester_Result semester_Result = db.Semester_Result.Find(id);
            db.Semester_Result.Remove(semester_Result);
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
