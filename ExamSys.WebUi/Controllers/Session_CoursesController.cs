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
    public class Session_CoursesController : Controller
    {
        private ExamDB db = new ExamDB();

        // GET: Session_Courses
        public ActionResult Index()
        {
            return View(db.Session_Courses.ToList());
        }

        // GET: Session_Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session_Courses session_Courses = db.Session_Courses.Find(id);
            if (session_Courses == null)
            {
                return HttpNotFound();
            }
            return View(session_Courses);
        }

        // GET: Session_Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Session_Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Session,Semester,Department,Faculty,Course,created_at,edited_at")] Session_Courses session_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Session_Courses.Add(session_Courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(session_Courses);
        }

        // GET: Session_Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session_Courses session_Courses = db.Session_Courses.Find(id);
            if (session_Courses == null)
            {
                return HttpNotFound();
            }
            return View(session_Courses);
        }

        // POST: Session_Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Session,Semester,Department,Faculty,Course,created_at,edited_at")] Session_Courses session_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session_Courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(session_Courses);
        }

        // GET: Session_Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session_Courses session_Courses = db.Session_Courses.Find(id);
            if (session_Courses == null)
            {
                return HttpNotFound();
            }
            return View(session_Courses);
        }

        // POST: Session_Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session_Courses session_Courses = db.Session_Courses.Find(id);
            db.Session_Courses.Remove(session_Courses);
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

        // Customize session courses 
        [HttpGet]
        public ActionResult getSessionCourses() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult getSessionCourses(FormCollection FC)
        {
            return RedirectToAction("showSessionCourses", "Session_Courses",
                new 
                {
                    session = int.Parse(FC["session"].ToString()),
                    dept = int.Parse(FC["department"].ToString())
                }
                );
            //return View();
        }
        public ActionResult showSessionCourses(int session,int dept) 
        {
            ViewBag.session = session;
            ViewBag.dept = dept;
            return View( db.Session_Courses.Where(m => m.Session == session &
                m.Department == dept
                ).ToList());
        }
    }
}
