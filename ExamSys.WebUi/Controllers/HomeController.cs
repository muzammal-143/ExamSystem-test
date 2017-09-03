using ExamSys.Database;
using ExamSys.Database.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.WebUi.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        public ActionResult seed() 
        {
            seed_All seed = new seed_All();
            seed.start();

            return View();
        }
        
        public ActionResult Index() 
        {
            return View();
        }




    }
}