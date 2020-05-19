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
    public class NssController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Nss/
        public ActionResult Index()
        {
            return View(db.National_services_status.ToList());
        }

        // GET: /Nss/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            National_services_status national_services_status = db.National_services_status.Find(id);
            if (national_services_status == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(national_services_status);
        }

        // GET: /Nss/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Nss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="National_services_status_id,National_services_status_name")] National_services_status national_services_status)
        {
            if (ModelState.IsValid)
            {
                db.National_services_status.Add(national_services_status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(national_services_status);
        }

        // GET: /Nss/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            National_services_status national_services_status = db.National_services_status.Find(id);
            if (national_services_status == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(national_services_status);
        }

        // POST: /Nss/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="National_services_status_id,National_services_status_name")] National_services_status national_services_status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(national_services_status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(national_services_status);
        }

        // GET: /Nss/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            National_services_status national_services_status = db.National_services_status.Find(id);
            if (national_services_status == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(national_services_status);
        }

        // POST: /Nss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            National_services_status national_services_status = db.National_services_status.Find(id);
            db.National_services_status.Remove(national_services_status);
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
