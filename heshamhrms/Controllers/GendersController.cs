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
    public class GendersController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Genders/
        public ActionResult Index()
        {
            return View(db.Genders.ToList());
        }

        // GET: /Genders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Genders genders = db.Genders.Find(id);
            if (genders == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(genders);
        }

        // GET: /Genders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Genders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Gender_id,Gender_name")] Genders genders)
        {
            if (ModelState.IsValid)
            {
                db.Genders.Add(genders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genders);
        }

        // GET: /Genders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Genders genders = db.Genders.Find(id);
            if (genders == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(genders);
        }

        // POST: /Genders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Gender_id,Gender_name")] Genders genders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genders);
        }

        // GET: /Genders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Genders genders = db.Genders.Find(id);
            if (genders == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(genders);
        }

        // POST: /Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genders genders = db.Genders.Find(id);
            db.Genders.Remove(genders);
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
