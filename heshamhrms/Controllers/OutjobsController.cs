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
    public class OutjobsController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Outjobs/
        public ActionResult Index()
        {
            var out_jobs = db.Out_jobs.Include(o => o.Departments).Include(o => o.Employees).Include(o => o.Users);
            return View(out_jobs.ToList());
        }

        // GET: /Outjobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Out_jobs out_jobs = db.Out_jobs.Find(id);
            if (out_jobs == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(out_jobs);
        }

        // GET: /Outjobs/Create
        public ActionResult Create()
        {
            ViewBag.Out_job_location_id = new SelectList(db.Departments, "Department_id", "Department_name");
            ViewBag.Out_job_employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            return View();
        }

        // POST: /Outjobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Out_job_id,Out_job_employee_id,Out_job_location_id,Out_job_date,Out_job_reason,Out_job_duration,Edit_by,Date_time")] Out_jobs out_jobs)
        {
            if (ModelState.IsValid)
            {
                db.Out_jobs.Add(out_jobs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Out_job_location_id = new SelectList(db.Departments, "Department_id", "Department_name", out_jobs.Out_job_location_id);
            ViewBag.Out_job_employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name", out_jobs.Out_job_employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", out_jobs.Edit_by);
            return View(out_jobs);
        }

        // GET: /Outjobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Out_jobs out_jobs = db.Out_jobs.Find(id);
            if (out_jobs == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Out_job_location_id = new SelectList(db.Departments, "Department_id", "Department_name", out_jobs.Out_job_location_id);
            ViewBag.Out_job_employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", out_jobs.Out_job_employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", out_jobs.Edit_by);
            return View(out_jobs);
        }

        // POST: /Outjobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Out_job_id,Out_job_employee_id,Out_job_location_id,Out_job_date,Out_job_reason,Out_job_duration,Edit_by,Date_time")] Out_jobs out_jobs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(out_jobs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Out_job_location_id = new SelectList(db.Departments, "Department_id", "Department_name", out_jobs.Out_job_location_id);
            ViewBag.Out_job_employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", out_jobs.Out_job_employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", out_jobs.Edit_by);
            return View(out_jobs);
        }

        // GET: /Outjobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Out_jobs out_jobs = db.Out_jobs.Find(id);
            if (out_jobs == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(out_jobs);
        }

        // POST: /Outjobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Out_jobs out_jobs = db.Out_jobs.Find(id);
            db.Out_jobs.Remove(out_jobs);
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
