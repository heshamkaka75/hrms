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
    public class ManifestationsController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Manifestations/
        public ActionResult Index()
        {
            var manifestations = db.Manifestations.Include(m => m.Employees).Include(m => m.Users);
            return View(manifestations.ToList());
        }

        // GET: /Manifestations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Manifestations manifestations = db.Manifestations.Find(id);
            if (manifestations == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(manifestations);
        }

        // GET: /Manifestations/Create
        public ActionResult Create()
        {
            ViewBag.Manifestation_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            return View();
        }

        // POST: /Manifestations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Manifestation_id,Manifestation_Employee_id,Manifestation_date,Manifestation_Reason,Edit_by,Date_time")] Manifestations manifestations)
        {
            if (ModelState.IsValid)
            {
                db.Manifestations.Add(manifestations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Manifestation_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", manifestations.Manifestation_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", manifestations.Edit_by);
            return View(manifestations);
        }

        // GET: /Manifestations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Manifestations manifestations = db.Manifestations.Find(id);
            if (manifestations == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Manifestation_Employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name", manifestations.Manifestation_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", manifestations.Edit_by);
            return View(manifestations);
        }

        // POST: /Manifestations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Manifestation_id,Manifestation_Employee_id,Manifestation_date,Manifestation_Reason,Edit_by,Date_time")] Manifestations manifestations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manifestations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Manifestation_Employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", manifestations.Manifestation_Employee_id);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", manifestations.Edit_by);
            return View(manifestations);
        }

        // GET: /Manifestations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Manifestations manifestations = db.Manifestations.Find(id);
            if (manifestations == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(manifestations);
        }

        // POST: /Manifestations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manifestations manifestations = db.Manifestations.Find(id);
            db.Manifestations.Remove(manifestations);
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
