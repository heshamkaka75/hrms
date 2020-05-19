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
    public class SacksController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Sacks/
        public ActionResult Index()
        {
            var sacks = db.sacks.Include(s => s.Employees).Include(s => s.Users);
            return View(sacks.ToList());
        }

        // GET: /Sacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            sacks sacks = db.sacks.Find(id);
            if (sacks == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(sacks);
        }

        // GET: /Sacks/Create
        public ActionResult Create()
        {
            ViewBag.sack_employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            return View();
        }

        // POST: /Sacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="sack_id,sack_employee_id,sack_data,Sack_Reason,Edit_by,Date_time")] sacks sacks)
        {
            if (ModelState.IsValid)
            {
                db.sacks.Add(sacks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sack_employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", sacks.sack_employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", sacks.Edit_by);
            return View(sacks);
        }

        // GET: /Sacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            sacks sacks = db.sacks.Find(id);
            if (sacks == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.sack_employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name", sacks.sack_employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", sacks.Edit_by);
            return View(sacks);
        }

        // POST: /Sacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="sack_id,sack_employee_id,sack_data,Sack_Reason,Edit_by,Date_time")] sacks sacks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sacks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sack_employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", sacks.sack_employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", sacks.Edit_by);
            return View(sacks);
        }

        // GET: /Sacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            sacks sacks = db.sacks.Find(id);
            if (sacks == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(sacks);
        }

        // POST: /Sacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sacks sacks = db.sacks.Find(id);
            db.sacks.Remove(sacks);
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
