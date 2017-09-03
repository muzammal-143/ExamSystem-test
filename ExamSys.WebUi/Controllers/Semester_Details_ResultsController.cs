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
    public class Semester_Details_ResultsController : Controller
    {
        private ExamDB db = new ExamDB();

        // GET: Semester_Details_Results
        public ActionResult Index()
        {
            return View(db.Semester_Details_Results.ToList());
        }

        // GET: Semester_Details_Results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Details_Results semester_Details_Results = db.Semester_Details_Results.Find(id);
            if (semester_Details_Results == null)
            {
                return HttpNotFound();
            }
            return View(semester_Details_Results);
        }

        // GET: Semester_Details_Results/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semester_Details_Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Semester,Total,Obtain,Comment,Save,Edit,Extension,Student,Department,Faculty,Course,Result_Type,created_at,edited_at")] Semester_Details_Results semester_Details_Results)
        {
            if (ModelState.IsValid)
            {
                db.Semester_Details_Results.Add(semester_Details_Results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semester_Details_Results);
        }

        // GET: Semester_Details_Results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Details_Results semester_Details_Results = db.Semester_Details_Results.Find(id);
            if (semester_Details_Results == null)
            {
                return HttpNotFound();
            }
            return View(semester_Details_Results);
        }

        // POST: Semester_Details_Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Semester,Total,Obtain,Comment,Save,Edit,Extension,Student,Department,Faculty,Course,Result_Type,created_at,edited_at")] Semester_Details_Results semester_Details_Results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semester_Details_Results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semester_Details_Results);
        }

        // GET: Semester_Details_Results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Details_Results semester_Details_Results = db.Semester_Details_Results.Find(id);
            if (semester_Details_Results == null)
            {
                return HttpNotFound();
            }
            return View(semester_Details_Results);
        }

        // POST: Semester_Details_Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semester_Details_Results semester_Details_Results = db.Semester_Details_Results.Find(id);
            db.Semester_Details_Results.Remove(semester_Details_Results);
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
