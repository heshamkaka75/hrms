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
    public class AuthController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Auth/
        public ActionResult Index()
        {
            return View(db.Authorities.ToList());
        }

        // GET: /Auth/Details/5

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorities authorities = db.Authorities.Find(id);
            if (authorities == null)
            {
                return HttpNotFound();
            }
            return View(authorities);
        }

        // GET: /Auth/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Auth/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="auth_id,auth_name")] Authorities authorities)
        {
            if (ModelState.IsValid)
            {
                db.Authorities.Add(authorities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorities);
        }

        // GET: /Auth/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorities authorities = db.Authorities.Find(id);
            if (authorities == null)
            {
                return HttpNotFound();
            }
            return View(authorities);
        }

        // POST: /Auth/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="auth_id,auth_name")] Authorities authorities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorities);
        }

        // GET: /Auth/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorities authorities = db.Authorities.Find(id);
            if (authorities == null)
            {
                return HttpNotFound();
            }
            return View(authorities);
        }

        // POST: /Auth/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authorities authorities = db.Authorities.Find(id);
            db.Authorities.Remove(authorities);
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
