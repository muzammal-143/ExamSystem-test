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
    public class ResultShowController : Controller
    {
        public ExamDB db = new ExamDB();
        // Show Results of single Student
        [HttpGet]
        public ActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Student(FormCollection FC)
        {
            var rollNo = FC["RollNo"].ToString();

            return RedirectToAction("showStudent", "ResultShow", new{ RollNo = rollNo.ToString()});
            //return View();
        }
        
        
        /// <summary>
        /// it is basically transcript
        /// </summary>
        /// <param name="RollNo"></param>
        /// <returns></returns>
        public ActionResult showStudent(string RollNo) 
        {
            var rollNo = RollNo.ToString();
            var stu = db.Students.SingleOrDefault(m => m.Roll_No == rollNo);
            ViewBag.Student = stu;
            var results = db.Semester_Result.Where(m => m.Student == stu.id).ToList();

            return View(results);
        }

        public ActionResult ChangeStudentStatus(FormCollection FC)
        {
            string rollNo   = FC["rollNo"];
            int status = int.Parse(FC["status"]);
            string comment = FC["comment"];

            var student = db.Students.SingleOrDefault(m => m.Roll_No == rollNo);
            student.Status = status;
            student.Comment = comment;
            db.SaveChanges();
            return RedirectToAction("showStudent", new { RollNo = rollNo });
        }


    }
}