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
    public class VacbalanceController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Vacbalance/
        public ActionResult Index()
        {
            var vacation_balances = db.Vacation_Balances.Include(v => v.Employees).Include(v => v.Vacations_type);
            return View(vacation_balances.ToList());
        }

        // GET: /Vacbalance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Vacation_Balances vacation_balances = db.Vacation_Balances.Find(id);
            if (vacation_balances == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(vacation_balances);
        }

        // GET: /Vacbalance/Create
        public ActionResult Create()
        {
            ViewBag.vb_emp_id = new SelectList(db.Employees, "Employee_id", "Employee_name");
            ViewBag.Vb_vt_id = new SelectList(db.Vacations_type, "Vacation_type_id", "Vacation_name");
            return View();
        }

        // POST: /Vacbalance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Vacation_Balances_id,Vb_vt_id,vb_emp_id,vb_total,edit_by,date_time")] Vacation_Balances vacation_balances)
        {
            if (ModelState.IsValid)
            {
                db.Vacation_Balances.Add(vacation_balances);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vb_emp_id = new SelectList(db.Employees, "Employee_id", "Employee_name", vacation_balances.vb_emp_id);
            ViewBag.Vb_vt_id = new SelectList(db.Vacations_type, "Vacation_type_id", "Vacation_name", vacation_balances.Vb_vt_id);
            return View(vacation_balances);
        }

        // GET: /Vacbalance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Vacation_Balances vacation_balances = db.Vacation_Balances.Find(id);
            if (vacation_balances == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.vb_emp_id = new SelectList(db.Employees, "Employee_id", "Employee_name", vacation_balances.vb_emp_id);
            ViewBag.Vb_vt_id = new SelectList(db.Vacations_type, "Vacation_type_id", "Vacation_name", vacation_balances.Vb_vt_id);
            return View(vacation_balances);
        }

        // POST: /Vacbalance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Vacation_Balances_id,Vb_vt_id,vb_emp_id,vb_total,edit_by,date_time")] Vacation_Balances vacation_balances)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacation_balances).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vb_emp_id = new SelectList(db.Employees, "Employee_id", "Employee_name", vacation_balances.vb_emp_id);
            ViewBag.Vb_vt_id = new SelectList(db.Vacations_type, "Vacation_type_id", "Vacation_name", vacation_balances.Vb_vt_id);
            return View(vacation_balances);
        }

        // GET: /Vacbalance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Vacation_Balances vacation_balances = db.Vacation_Balances.Find(id);
            if (vacation_balances == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(vacation_balances);
        }

        // POST: /Vacbalance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacation_Balances vacation_balances = db.Vacation_Balances.Find(id);
            db.Vacation_Balances.Remove(vacation_balances);
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
