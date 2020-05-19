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
    public class ResingnsController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Resingns/
        public ActionResult Index()
        {
            var resigns = db.Resigns.Include(r => r.Employees).Include(r => r.Users);
            return View(resigns.ToList());
        }

        // GET: /Resingns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Resigns resigns = db.Resigns.Find(id);
            if (resigns == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(resigns);
        }

        // GET: /Resingns/Create
        public ActionResult Create()
        {
            ViewBag.Resign_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            return View();
        }

        // POST: /Resingns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Resign_id,Resign_Employee_id,Resign_date,Resign_Reason,Edit_by,Date_time")] Resigns resigns)
        {
            if (ModelState.IsValid)
            {
                db.Resigns.Add(resigns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Resign_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", resigns.Resign_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", resigns.Edit_by);
            return View(resigns);
        }

        // GET: /Resingns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Resigns resigns = db.Resigns.Find(id);
            if (resigns == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Resign_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name", resigns.Resign_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", resigns.Edit_by);
            return View(resigns);
        }

        // POST: /Resingns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Resign_id,Resign_Employee_id,Resign_date,Resign_Reason,Edit_by,Date_time")] Resigns resigns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resigns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Resign_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", resigns.Resign_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", resigns.Edit_by);
            return View(resigns);
        }

        // GET: /Resingns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Resigns resigns = db.Resigns.Find(id);
            if (resigns == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(resigns);
        }

        // POST: /Resingns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resigns resigns = db.Resigns.Find(id);
            db.Resigns.Remove(resigns);
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
