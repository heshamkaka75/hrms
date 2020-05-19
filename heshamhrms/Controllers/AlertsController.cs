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
    public class AlertsController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Alerts/
        public ActionResult Index()
        {
            var alerts = db.alerts.Include(a => a.Users).Include(a => a.Employees);
            return View(alerts.ToList());
        }

        // GET: /Alerts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
                
            }
            alerts alerts = db.alerts.Find(id);
            if (alerts == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(alerts);
        }

        // GET: /Alerts/Create
        public ActionResult Create()
        {
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            ViewBag.Alert_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            return View();
        }

        // POST: /Alerts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="alert_id,Alert_Employee_id,alert_date,alert_Reason,Edit_by,Date_time")] alerts alerts)
        {
            if (ModelState.IsValid)
            {
                db.alerts.Add(alerts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", alerts.Edit_by);
            ViewBag.Alert_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", alerts.Alert_Employee_id);
            return View(alerts);
        }

        // GET: /Alerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            alerts alerts = db.alerts.Find(id);
            if (alerts == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", alerts.Edit_by);
            ViewBag.Alert_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name", alerts.Alert_Employee_id);
            return View(alerts);
        }

        // POST: /Alerts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="alert_id,Alert_Employee_id,alert_date,alert_Reason,Edit_by,Date_time")] alerts alerts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alerts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", alerts.Edit_by);
            ViewBag.Alert_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", alerts.Alert_Employee_id);
            return View(alerts);
        }

        // GET: /Alerts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            alerts alerts = db.alerts.Find(id);
            if (alerts == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(alerts);
        }

        // POST: /Alerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alerts alerts = db.alerts.Find(id);
            db.alerts.Remove(alerts);
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
