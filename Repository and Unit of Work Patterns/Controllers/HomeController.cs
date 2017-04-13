using PagedList;
using Repository_and_Unit_of_Work_Patterns.DAL;
using Repository_and_Unit_of_Work_Patterns.Models;
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
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.Message = "Welcome to Contoso University";
            

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            var students = from s in db.Students
                           select s;
            switch (sortOrder)
            {
                case "Name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "Date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.student = students.ToPagedList(pageNumber, pageSize);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details (int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student )
        {
            var s = db.Students.Find(student.StudentID);

            s.LastName = student.LastName;
            s.FirstMidName = student.FirstMidName;

            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}