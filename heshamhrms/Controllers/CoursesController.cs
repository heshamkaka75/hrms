using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using heshamhrms.Models;

namespace heshamhrms.Controllers
{
    public class CoursesController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Courses/
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Courses_name).Include(c => c.Users).Include(c => c.Employees);
            return View(courses.ToList());
        }

        // GET: /Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(courses);
        }

        // GET: /Courses/Create
        public ActionResult Create()
        {
            ViewBag.Course_Course_name_id = new SelectList(db.Courses_name, "Course_name_id", "Course_name");
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            ViewBag.Course_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            return View();
        }

        // POST: /Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Course_id,Course_Course_name_id,Course_Employee_id,Course_location,Course_start_date,Course_end_date,Support_from,Edit_by,Date_time")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_Course_name_id = new SelectList(db.Courses_name, "Course_name_id", "Course_name", courses.Course_Course_name_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", courses.Edit_by);
            ViewBag.Course_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", courses.Course_Employee_id);
            return View(courses);
        }

        // GET: /Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Course_Course_name_id = new SelectList(db.Courses_name, "Course_name_id", "Course_name", courses.Course_Course_name_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", courses.Edit_by);
            ViewBag.Course_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name", courses.Course_Employee_id);
            return View(courses);
        }

        // POST: /Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Course_id,Course_Course_name_id,Course_Employee_id,Course_location,Course_start_date,Course_end_date,Support_from,Edit_by,Date_time")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Course_name_id = new SelectList(db.Courses_name, "Course_name_id", "Course_name", courses.Course_Course_name_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", courses.Edit_by);
            ViewBag.Course_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", courses.Course_Employee_id);
            return View(courses);
        }

        // GET: /Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(courses);
        }

        // POST: /Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courses courses = db.Courses.Find(id);
            db.Courses.Remove(courses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
