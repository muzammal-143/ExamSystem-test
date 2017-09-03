using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.WebUi.Controllers
{
    public class FacultyManagementController : Controller
    {
        // GET: FacultyManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TimeTable(string userName) 
        {
            ViewBag.userName = userName;
            return View();
        }

        [HttpPost]
        public ActionResult TimeTable(FormCollection FC)
        {
            ViewBag.userName = FC["userName"];
            ViewBag.session = FC["session"];
            return View();
        }
        public ActionResult TimeExpired() 
        {
            return View();
        }
    }
}