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
    public class TransfersController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Transfers/
        public ActionResult Index()
        {
            var transfers = db.Transfers.Include(t => t.Departments).Include(t => t.Departments1).Include(t => t.Employees).Include(t => t.Users);
            return View(transfers.ToList());
        }

        // GET: /Transfers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Transfers transfers = db.Transfers.Find(id);
            if (transfers == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(transfers);
        }

        // GET: /Transfers/Create
        public ActionResult Create()
        {
            ViewBag.Transfer_from_department_id = new SelectList(db.Departments.OrderBy(item => item.Department_name), "Department_id", "Department_name");
            ViewBag.Transfer_to_department_id = new SelectList(db.Departments.OrderBy(item => item.Department_name), "Department_id", "Department_name");
            ViewBag.Transfer_employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            return View();
        }

        // POST: /Transfers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Transfer_id,Transfer_employee_id,Transfer_from_department_id,Transfer_to_department_id,Edit_by,Date_time")] Transfers transfers)
        {
            if (ModelState.IsValid)
            {
                db.Transfers.Add(transfers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Transfer_from_department_id = new SelectList(db.Departments, "Department_id", "Department_name", transfers.Transfer_from_department_id);
            ViewBag.Transfer_to_department_id = new SelectList(db.Departments, "Department_id", "Department_name", transfers.Transfer_to_department_id);
            ViewBag.Transfer_employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", transfers.Transfer_employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", transfers.Edit_by);
            return View(transfers);
        }

        // GET: /Transfers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Transfers transfers = db.Transfers.Find(id);
            if (transfers == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Transfer_from_department_id = new SelectList(db.Departments.OrderBy(item => item.Department_name), "Department_id", "Department_name", transfers.Transfer_from_department_id);
            ViewBag.Transfer_to_department_id = new SelectList(db.Departments.OrderBy(item => item.Department_name), "Department_id", "Department_name", transfers.Transfer_to_department_id);
            ViewBag.Transfer_employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name", transfers.Transfer_employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", transfers.Edit_by);
            return View(transfers);
        }

        // POST: /Transfers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Transfer_id,Transfer_employee_id,Transfer_from_department_id,Transfer_to_department_id,Edit_by,Date_time")] Transfers transfers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transfers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Transfer_from_department_id = new SelectList(db.Departments, "Department_id", "Department_name", transfers.Transfer_from_department_id);
            ViewBag.Transfer_to_department_id = new SelectList(db.Departments, "Department_id", "Department_name", transfers.Transfer_to_department_id);
            ViewBag.Transfer_employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", transfers.Transfer_employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", transfers.Edit_by);
            return View(transfers);
        }

        // GET: /Transfers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Transfers transfers = db.Transfers.Find(id);
            if (transfers == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(transfers);
        }

        // POST: /Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transfers transfers = db.Transfers.Find(id);
            db.Transfers.Remove(transfers);
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
