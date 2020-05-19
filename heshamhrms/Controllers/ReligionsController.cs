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
    public class ReligionsController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Religions/
        public ActionResult Index()
        {
            return View(db.Religions.ToList());
        }

        // GET: /Religions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Religions religions = db.Religions.Find(id);
            if (religions == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(religions);
        }

        // GET: /Religions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Religions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Religion_id,Religion_name")] Religions religions)
        {
            if (ModelState.IsValid)
            {
                db.Religions.Add(religions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(religions);
        }

        // GET: /Religions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Religions religions = db.Religions.Find(id);
            if (religions == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(religions);
        }

        // POST: /Religions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Religion_id,Religion_name")] Religions religions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(religions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(religions);
        }

        // GET: /Religions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Religions religions = db.Religions.Find(id);
            if (religions == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(religions);
        }

        // POST: /Religions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Religions religions = db.Religions.Find(id);
            db.Religions.Remove(religions);
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
