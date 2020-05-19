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
    public class CertificatesController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Certificates/
        public ActionResult Index()
        {
            var certificates = db.Certificates.Include(c => c.Users).Include(c => c.Employees);
            return View(certificates.ToList());
        }

        // GET: /Certificates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Certificates certificates = db.Certificates.Find(id);
            if (certificates == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(certificates);
        }

        // GET: /Certificates/Create
        public ActionResult Create()
        {
            ViewBag.edit_by = new SelectList(db.Users, "User_id", "User_name");
            ViewBag.Certificate_employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            return View();
        }

        // POST: /Certificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Certificate_id,Certificate_employee_id,Certificate_name,edit_by,date_time,Certificate_type,Certificate_source,Certificate_duration,Certificate_from,Certificate_to")] Certificates certificates)
        {
            if (ModelState.IsValid)
            {
                db.Certificates.Add(certificates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.edit_by = new SelectList(db.Users, "User_id", "User_name", certificates.edit_by);
            ViewBag.Certificate_employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", certificates.Certificate_employee_id);
            return View(certificates);
        }

        // GET: /Certificates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Certificates certificates = db.Certificates.Find(id);
            if (certificates == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.edit_by = new SelectList(db.Users, "User_id", "User_name", certificates.edit_by);
            ViewBag.Certificate_employee_id = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name", certificates.Certificate_employee_id);
            return View(certificates);
        }

        // POST: /Certificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Certificate_id,Certificate_employee_id,Certificate_name,edit_by,date_time,Certificate_type,Certificate_source,Certificate_duration,Certificate_from,Certificate_to")] Certificates certificates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certificates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.edit_by = new SelectList(db.Users, "User_id", "User_name", certificates.edit_by);
            ViewBag.Certificate_employee_id = new SelectList(db.Employees, "Employee_id", "Employee_name", certificates.Certificate_employee_id);
            return View(certificates);
        }

        // GET: /Certificates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Certificates certificates = db.Certificates.Find(id);
            if (certificates == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(certificates);
        }

        // POST: /Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Certificates certificates = db.Certificates.Find(id);
            db.Certificates.Remove(certificates);
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
