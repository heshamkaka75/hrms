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
    public class StopworkController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Stopwork/
        public ActionResult Index()
        {
            var stop_working = db.stop_working.Include(s => s.Employees).Include(s => s.Users);
            return View(stop_working.ToList());
        }

        // GET: /Stopwork/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            stop_working stop_working = db.stop_working.Find(id);
            if (stop_working == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(stop_working);
        }

        // GET: /Stopwork/Create
        public ActionResult Create()
        {
            ViewBag.stop_working_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            return View();
        }

        // POST: /Stopwork/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="stop_working_id,stop_working_Employee_id,stop_working_date,stop_working_Reason,Edit_by,Date_time")] stop_working stop_working)
        {
            if (ModelState.IsValid)
            {
                db.stop_working.Add(stop_working);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.stop_working_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", stop_working.stop_working_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", stop_working.Edit_by);
            return View(stop_working);
        }

        // GET: /Stopwork/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            stop_working stop_working = db.stop_working.Find(id);
            if (stop_working == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.stop_working_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name", stop_working.stop_working_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", stop_working.Edit_by);
            return View(stop_working);
        }

        // POST: /Stopwork/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="stop_working_id,stop_working_Employee_id,stop_working_date,stop_working_Reason,Edit_by,Date_time")] stop_working stop_working)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stop_working).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.stop_working_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", stop_working.stop_working_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", stop_working.Edit_by);
            return View(stop_working);
        }

        // GET: /Stopwork/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            stop_working stop_working = db.stop_working.Find(id);
            if (stop_working == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(stop_working);
        }

        // POST: /Stopwork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stop_working stop_working = db.stop_working.Find(id);
            db.stop_working.Remove(stop_working);
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
