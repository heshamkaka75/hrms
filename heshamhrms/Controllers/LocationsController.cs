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
    public class LocationsController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Locations/
        public ActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        // GET: /Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Locations locations = db.Locations.Find(id);
            if (locations == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(locations);
        }

        // GET: /Locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Location_id,Location_name,city,address,Phone_no")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(locations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locations);
        }

        // GET: /Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Locations locations = db.Locations.Find(id);
            if (locations == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(locations);
        }

        // POST: /Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Location_id,Location_name,city,address,Phone_no")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locations);
        }

        // GET: /Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Locations locations = db.Locations.Find(id);
            if (locations == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(locations);
        }

        // POST: /Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locations locations = db.Locations.Find(id);
            db.Locations.Remove(locations);
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
