using ExamSys.Database;
using ExamSys.Logics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.WebUi.Controllers
{
    public class AdminController : Controller
    {
        private ExamDB db = new ExamDB();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        // create results for all the university
        public string CR() 
        {
            GazzeteCreation g = new GazzeteCreation();
            var activeUser = db.Faculties.SingleOrDefault(m => m.UserName == HttpContext.User.Identity.Name);
            g.CreateResult(activeUser);
            return "done";
        }



        [HttpGet]
        public ActionResult TaskDate()
        {
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public ActionResult TaskDate(FormCollection FC)
        {
            int designation = int.Parse(FC["designation"]);
            DateTime date = DateTime.Parse(FC["date"]);
            string comment = FC["comment"];

            var des = db.Faculties.Where(m => m.Designation == designation);

            des.ToList().ForEach(m => m.TimeExtension = date);
            des.ToList().ForEach(m => m.edited_at = DateTime.Now);
            des.ToList().ForEach(m => m.Comment = comment);

            db.SaveChanges();
            ViewBag.Message = "Successfully";

            return View();
        }
        [HttpGet]
        public ActionResult ExtendDate()
        {
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public ActionResult ExtendDate(FormCollection FC) 
        {
            int facultyId = int.Parse(FC["facultyId"]);
            DateTime date = DateTime.Parse(FC["date"]);
            string comment = FC["comment"];

            var des = db.Faculties.Single(m => m.Designation == facultyId);

            des.TimeExtension = date;
            des.edited_at = DateTime.Now;
            des.Comment = comment;

            ViewBag.Message = "Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult getStudentsForStatus() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult getStudentsForStatus(FormCollection FC)
        {
            int status = int.Parse(FC["status"]);
            int session = int.Parse(FC["session"]);db.Students.Where(m => m.Session == session & m.Status == status).ToList();
            return RedirectToAction("showStudentStatus", new { session = session, status = status });
        }
        
        public ActionResult showStudentStatus(int session,int status)
        {
            ViewBag.Session = session;
            ViewBag.StudentStatus = db.Statuses.Find(status).Title;
            return View(db.Students.Where(m => m.Session == session & m.Status == status).ToList());
        }


        public ActionResult DesignationTaskStatus() 
        {
            return View();
        }

    }
}