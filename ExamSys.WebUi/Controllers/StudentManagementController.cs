using ExamSys.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.WebUi.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentManagementController : Controller
    {
        private ExamDB db = new ExamDB();
        // GET: StudentManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Transcript() 
        {
            var user = db.Students.SingleOrDefault(m => m.Roll_No == User.Identity.Name);
            var results = db.Semester_Result.Where(m => m.Student == user.id).ToList();

            return View(results);
        }

        [AllowAnonymous]
        public string test()
        {
            return HttpContext.User.Identity.Name;
        }

        public ActionResult SemesterCourses() 
        {
            var user = db.Students.SingleOrDefault(m => m.Roll_No == User.Identity.Name);
            var Courses = from c in db.Courses
                          from sc in db.Session_Courses
                          where
                              sc.Course == c.id &&
                              sc.Session == user.Session &&
                              sc.Semester == user.Semester &&
                              sc.Department == user.Department
                              
                          select new
                          {
                              cou = c
                          };

            return View(Courses.Select(m=>m.cou).ToList());
        }

        public ActionResult StudentCourses()
        {
            var user = db.Students.SingleOrDefault(m => m.Roll_No == User.Identity.Name);
            var SessionCourses = db.Session_Courses
                          .Where(sc =>
                              sc.Session == user.Session &&
                              sc.Department == user.Department
                              ).ToList();

            return View(SessionCourses);
        }

        public ActionResult ResultDetails() 
        {
            return View();
        }

    }
}
