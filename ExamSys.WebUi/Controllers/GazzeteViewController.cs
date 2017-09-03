using ExamSys.Database;
using ExamSys.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.WebUi.Controllers
{
    public class GazzeteViewController : Controller
    {
        private ExamDB db = new ExamDB();
        // Customize session courses 
        [HttpGet]
        public ActionResult getDeptSemester()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getDeptSemester(FormCollection FC)
        {
            var year = FC[0];
            var dept = FC[1];
            var sem = FC[2];
            return RedirectToAction("show", "GazzeteView",
                new
                {
                    session = int.Parse(year),
                    dept    = int.Parse(dept),
                    semester= int.Parse(sem)
                }
                );
            //return View();
        }
        public ActionResult show(int session, int dept, int semester)
        {
            ViewBag.session = session;
            ViewBag.dept = dept;
            ViewBag.semester = semester;

            ViewBag.SessionCourses = db.Courses.Where( 
                    c=>
                    db.Session_Courses.Where(
                    m => m.Session == session &
                        m.Department == dept &
                        m.Semester == semester
                    ).Select(m=>m.Course).Contains(c.id)
                ).ToList();
            GazzeteView_Details gvd = new GazzeteView_Details();
            var x = gvd.get(session, dept, semester);
            return View(gvd.get(session,dept,semester));
        }
    }
}