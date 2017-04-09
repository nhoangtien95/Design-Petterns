using Repository_and_Unit_of_Work_Patterns.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository_and_Unit_of_Work_Patterns.Controllers
{
    
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Contoso University";
            ViewBag.student = db.Students.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}