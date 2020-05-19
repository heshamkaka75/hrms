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
    public class RanksController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Ranks/
        public ActionResult Index()
        {
            return View(db.ranks.ToList());
        }

        // GET: /Ranks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ranks ranks = db.ranks.Find(id);
            if (ranks == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(ranks);
        }

        // GET: /Ranks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ranks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="rank_id,rank_name")] ranks ranks)
        {
            if (ModelState.IsValid)
            {
                db.ranks.Add(ranks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ranks);
        }

        // GET: /Ranks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ranks ranks = db.ranks.Find(id);
            if (ranks == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(ranks);
        }

        // POST: /Ranks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="rank_id,rank_name")] ranks ranks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ranks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ranks);
        }

        // GET: /Ranks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ranks ranks = db.ranks.Find(id);
            if (ranks == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(ranks);
        }

        // POST: /Ranks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ranks ranks = db.ranks.Find(id);
            db.ranks.Remove(ranks);
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
