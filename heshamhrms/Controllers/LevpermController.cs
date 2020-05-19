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
    public class LevpermController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Levperm/
        public ActionResult Index()
        {
            var leave_permission = db.Leave_permission.Include(l => l.Employees).Include(l => l.Users);
            return View(leave_permission.ToList());
        }

        // GET: /Levperm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Leave_permission leave_permission = db.Leave_permission.Find(id);
            if (leave_permission == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(leave_permission);
        }

        // GET: /Levperm/Create
        public ActionResult Create()
        {
            ViewBag.leave_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            return View();
        }

        // POST: /Levperm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "leave_id,leave_Employee_id,Leave_loc,leave_Duration,Leave_Reason,Edit_by,Date_time")] Leave_permission leave_permission)
        {
            if (ModelState.IsValid)
            {
                db.Leave_permission.Add(leave_permission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.leave_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", leave_permission.leave_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", leave_permission.Edit_by);
            return View(leave_permission);
        }

        // GET: /Levperm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Leave_permission leave_permission = db.Leave_permission.Find(id);
            if (leave_permission == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.leave_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name", leave_permission.leave_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", leave_permission.Edit_by);
            return View(leave_permission);
        }

        // POST: /Levperm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "leave_id,leave_Employee_id,leave_loc,leave_Duration,Leave_Reason,Edit_by,Date_time")] Leave_permission leave_permission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leave_permission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.leave_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", leave_permission.leave_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", leave_permission.Edit_by);
            return View(leave_permission);
        }

        // GET: /Levperm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Leave_permission leave_permission = db.Leave_permission.Find(id);
            if (leave_permission == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(leave_permission);
        }

        // POST: /Levperm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leave_permission leave_permission = db.Leave_permission.Find(id);
            db.Leave_permission.Remove(leave_permission);
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
