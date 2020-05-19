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
    public class CoursesnameController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Coursesname/
        public ActionResult Index()
        {
            return View(db.Courses_name.ToList());
        }

        // GET: /Coursesname/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Courses_name courses_name = db.Courses_name.Find(id);
            if (courses_name == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(courses_name);
        }

        // GET: /Coursesname/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Coursesname/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Course_name_id,Course_name")] Courses_name courses_name)
        {
            if (ModelState.IsValid)
            {
                db.Courses_name.Add(courses_name);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courses_name);
        }

        // GET: /Coursesname/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Courses_name courses_name = db.Courses_name.Find(id);
            if (courses_name == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(courses_name);
        }

        // POST: /Coursesname/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Course_name_id,Course_name")] Courses_name courses_name)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses_name).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses_name);
        }

        // GET: /Coursesname/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Courses_name courses_name = db.Courses_name.Find(id);
            if (courses_name == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(courses_name);
        }

        // POST: /Coursesname/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courses_name courses_name = db.Courses_name.Find(id);
            db.Courses_name.Remove(courses_name);
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
