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
    public class FacultiesController : Controller
    {
        private ExamDB db = new ExamDB();

        // GET: Faculties
        public ActionResult Index()
        {
            return View(db.Faculties.ToList());
        }

        // GET: Faculties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculties faculties = db.Faculties.Find(id);
            if (faculties == null)
            {
                return HttpNotFound();
            }
            return View(faculties);
        }

        // GET: Faculties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserName,Password,Activation,FirstName,LastName,Gender,Picture,Comment,TimeExtension,Designation,created_at,edited_at")] Faculties faculties)
        {
            if (ModelState.IsValid)
            {
                db.Faculties.Add(faculties);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faculties);
        }

        // GET: Faculties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculties faculties = db.Faculties.Find(id);
            if (faculties == null)
            {
                return HttpNotFound();
            }
            return View(faculties);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserName,Password,Activation,FirstName,LastName,Gender,Picture,Comment,TimeExtension,Designation,created_at,edited_at")] Faculties faculties)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculties).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculties);
        }

        // GET: Faculties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculties faculties = db.Faculties.Find(id);
            if (faculties == null)
            {
                return HttpNotFound();
            }
            return View(faculties);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculties faculties = db.Faculties.Find(id);
            db.Faculties.Remove(faculties);
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
