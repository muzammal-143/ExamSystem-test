using ExamSys.Database;
using ExamSys.Database.dbEntities;
using ExamSys.Database.Seeds;
using ExamSys.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExamSys.WebUi.Controllers
{
    public class AccountsAdminController : Controller
    {

        ExamDB db = new ExamDB();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginView user)
        {
            var u = db.Faculties.SingleOrDefault(m => m.UserName == user.UserName & m.Password == user.Password);
            if (u != null)
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
            }
            return RedirectToAction("Index", "Courses");
        }

        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}