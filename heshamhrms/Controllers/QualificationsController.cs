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
    public class QualificationsController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Qualifications/
        public ActionResult Index()
        {
            return View(db.Qualifications.ToList());
        }

        // GET: /Qualifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Qualifications qualifications = db.Qualifications.Find(id);
            if (qualifications == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(qualifications);
        }

        // GET: /Qualifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Qualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Qualification_id,Qualification_name")] Qualifications qualifications)
        {
            if (ModelState.IsValid)
            {
                db.Qualifications.Add(qualifications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qualifications);
        }

        // GET: /Qualifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Qualifications qualifications = db.Qualifications.Find(id);
            if (qualifications == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(qualifications);
        }

        // POST: /Qualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Qualification_id,Qualification_name")] Qualifications qualifications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualifications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qualifications);
        }

        // GET: /Qualifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Qualifications qualifications = db.Qualifications.Find(id);
            if (qualifications == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(qualifications);
        }

        // POST: /Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qualifications qualifications = db.Qualifications.Find(id);
            db.Qualifications.Remove(qualifications);
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
