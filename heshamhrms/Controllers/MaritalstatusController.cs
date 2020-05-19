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
    public class MaritalstatusController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Maritalstatus/
        public ActionResult Index()
        {
            return View(db.Marital_Status.ToList());
        }

        // GET: /Maritalstatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Marital_Status marital_status = db.Marital_Status.Find(id);
            if (marital_status == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(marital_status);
        }

        // GET: /Maritalstatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Maritalstatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Marital_Status_id,Marital_Status_name")] Marital_Status marital_status)
        {
            if (ModelState.IsValid)
            {
                db.Marital_Status.Add(marital_status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marital_status);
        }

        // GET: /Maritalstatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Marital_Status marital_status = db.Marital_Status.Find(id);
            if (marital_status == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(marital_status);
        }

        // POST: /Maritalstatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Marital_Status_id,Marital_Status_name")] Marital_Status marital_status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marital_status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marital_status);
        }

        // GET: /Maritalstatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Marital_Status marital_status = db.Marital_Status.Find(id);
            if (marital_status == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(marital_status);
        }

        // POST: /Maritalstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marital_Status marital_status = db.Marital_Status.Find(id);
            db.Marital_Status.Remove(marital_status);
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
