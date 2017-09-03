using ExamSys.Database;
using ExamSys.Logics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.WebUi.Controllers
{
    public class GazzeteCreateController : Controller
    {
        private ExamDB db = new ExamDB();
        // GET: GazzeteCreate
        public ActionResult Index(){
            return View();
        }
        public ActionResult Create()
        {
            GazzeteCreation g = new GazzeteCreation();
            if (g.CreateResultCheck())
            {
                var activeUser = db.Faculties.SingleOrDefault(m => m.UserName == HttpContext.User.Identity.Name);
                g.CreateResult(activeUser);

                StudentsRefreshStatuses refreshStatuses = new StudentsRefreshStatuses();
                refreshStatuses.RefreshStatuses();
                ViewBag.Message = "Created Successfully";
                return View();
            }
            else
            {
                ViewBag.Message = "Already created result";
                return View();

            }
            
        }

    }
}