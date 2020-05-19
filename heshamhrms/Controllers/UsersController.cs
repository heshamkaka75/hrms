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
    public class UsersController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Users/
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Authorities);
            return View(users.ToList());
        }

        // GET: /Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(users);
        }

        // GET: /Users/Create
        public ActionResult Create()
        {
            
            ViewBag.User_auth_id = new SelectList(db.Authorities.OrderBy(x=>x.auth_name), "auth_id", "auth_name");
            return View();
        }

        // POST: /Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="User_id,User_name,password,fullname,User_auth_id")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_auth_id = new SelectList(db.Authorities, "auth_id", "auth_name", users.User_auth_id);
            return View(users);
        }

        // GET: /Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.User_auth_id = new SelectList(db.Authorities, "auth_id", "auth_name", users.User_auth_id);
            return View(users);
        }

        // POST: /Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="User_id,User_name,password,fullname,User_auth_id")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_auth_id = new SelectList(db.Authorities, "auth_id", "auth_name", users.User_auth_id);
            return View(users);
        }

        // GET: /Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(users);
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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
