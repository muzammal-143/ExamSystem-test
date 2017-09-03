using ExamSys.Database;
using ExamSys.Database.dbEntities;
using ExamSys.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.WebUi.Controllers
{
    public class ResultCreateController : Controller
    {
        private ExamDB db = new ExamDB();
        // GET: CreateResult
        [HttpGet]
        public ActionResult GetStudents()
        {

            var activeUser = db.Faculties.SingleOrDefault(m => m.UserName == User.Identity.Name);
            if ((DateTime.Now - activeUser.TimeExtension).TotalSeconds < 0)
                return View();
            else return RedirectToAction("TimeExpired", "FacultyManagement");
        }

        [HttpPost]
        public ActionResult GetStudents(GetStudentView sView)
        {
            var students = db.Students
                .Where(
                    m => (m.Status == 1 || m.Status == 2 ) &
                    m.Department == sView.dept &
                    m.Semester == sView.semester
                ).ToList();
            Session["GetStudentView"] = sView;
            Session["StudentsList"]   = students;
            return RedirectToAction("CreateNow");
        }

        [HttpGet]
        public ActionResult CreateNow() {
            var students = (List<Students>)Session["StudentsList"];
            return View(students);
        }

        [HttpPost]
        public ActionResult CreateNow( FormCollection FC )
        {
            var sView = (GetStudentView)Session["GetStudentView"];
            var students = (List<Students>)Session["StudentsList"];
            var x = FC;
            int faculty = db.Faculties.SingleOrDefault(m => m.UserName == User.Identity.Name).id;
            foreach (var stu in students)
            {
                db.Semester_Details_Results.Add(
                    new Semester_Details_Results
                    {
                         Student    = stu.id,
                         Department = sView.dept,
                         Result_Type= sView.result_type,
                         Semester   = sView.semester,
                         Course     = sView.Course,
                         Faculty    = faculty,
                         Total      = double.Parse(FC["Total_"+stu.id]),
                         Obtain     = double.Parse(FC["Obtain_"+stu.id]),
                         Comment    = "",
                         Edit       = true,
                         Save       =   true,
                         created_at = DateTime.Now,
                         edited_at  = DateTime.Now,
                         Extension  = DateTime.Now,
                    });
            }
            db.SaveChanges();
            // Deleting sessions
            Session["GetStudentView"] = "";
            Session["StudentsList"] = "";
            return RedirectToAction("Success");
        }

        public ActionResult Success() 
        {
            return View();
        }


    }
}