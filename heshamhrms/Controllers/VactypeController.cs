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
    public class VactypeController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Vactype/
        public ActionResult Index()
        {
            return View(db.Vacations_type.ToList());
        }

        // GET: /Vactype/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Vacations_type vacations_type = db.Vacations_type.Find(id);
            if (vacations_type == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(vacations_type);
        }

        // GET: /Vactype/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Vactype/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Vacation_type_id,Vacation_name")] Vacations_type vacations_type)
        {
            if (ModelState.IsValid)
            {
                db.Vacations_type.Add(vacations_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacations_type);
        }

        // GET: /Vactype/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Vacations_type vacations_type = db.Vacations_type.Find(id);
            if (vacations_type == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(vacations_type);
        }

        // POST: /Vactype/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Vacation_type_id,Vacation_name")] Vacations_type vacations_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacations_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacations_type);
        }

        // GET: /Vactype/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Vacations_type vacations_type = db.Vacations_type.Find(id);
            if (vacations_type == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(vacations_type);
        }

        // POST: /Vactype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacations_type vacations_type = db.Vacations_type.Find(id);
            db.Vacations_type.Remove(vacations_type);
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
