using ExamSys.Database;
using ExamSys.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExamSys.WebUi.Controllers
{
    public class AccountsStudentsController : Controller
    {
        public ExamDB db = new ExamDB();
        // GET: AccountsStudents
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
            var u = db.Students.SingleOrDefault(m => m.Roll_No == user.UserName & m.Password == user.Password);
            if (u != null)
            {
                FormsAuthentication.SetAuthCookie(u.Roll_No, false);
            }
            return RedirectToAction("Index", "StudentManagement");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}