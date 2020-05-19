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
    public class DepartmentsController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Departments/
        public ActionResult Index()
        {
            var departments = db.Departments.Include(d => d.Locations).Include(d => d.Employees1);
            return View(departments.ToList());
        }

        // GET: /Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(departments);
        }

        // GET: /Departments/Create
        public ActionResult Create()
        {
            ViewBag.Department_Location_id = new SelectList(db.Locations, "Location_id", "Location_name");
            ViewBag.Manger_id = new SelectList(db.Employees, "Employee_id", "Employee_name");
            return View();
        }

        // POST: /Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Department_id,Department_name,Manger_id,Department_Location_id")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(departments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Department_Location_id = new SelectList(db.Locations, "Location_id", "Location_name", departments.Department_Location_id);
            ViewBag.Manger_id = new SelectList(db.Employees, "Employee_id", "Employee_name", departments.Manger_id);
            return View(departments);
        }

        // GET: /Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Department_Location_id = new SelectList(db.Locations, "Location_id", "Location_name", departments.Department_Location_id);
            ViewBag.Manger_id = new SelectList(db.Employees, "Employee_id", "Employee_name", departments.Manger_id);
            return View(departments);
        }

        // POST: /Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Department_id,Department_name,Manger_id,Department_Location_id")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department_Location_id = new SelectList(db.Locations, "Location_id", "Location_name", departments.Department_Location_id);
            ViewBag.Manger_id = new SelectList(db.Employees, "Employee_id", "Employee_name", departments.Manger_id);
            return View(departments);
        }

        // GET: /Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(departments);
        }

        // POST: /Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departments departments = db.Departments.Find(id);
            db.Departments.Remove(departments);
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
