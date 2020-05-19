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
    public class TriningsController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Trinings/
        public ActionResult Index()
        {
            var trainings = db.trainings.Include(t => t.Countries).Include(t => t.Departments).Include(t => t.Marital_Status).Include(t => t.Qualifications).Include(t => t.Religions);
            return View(trainings.ToList());
        }

        // GET: /Trinings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            trainings trainings = db.trainings.Find(id);
            if (trainings == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(trainings);
        }

        // GET: /Trinings/Create
        public ActionResult Create()
        {
            ViewBag.Country_id = new SelectList(db.Countries, "Country_id", "Country_name");
            ViewBag.Department_id = new SelectList(db.Departments, "Department_id", "Department_name");
            ViewBag.training_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name");
            ViewBag.training_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name");
            ViewBag.training_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name");
            return View();
        }

        // POST: /Trinings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="training_id,training_name,Date_of_birth,Country_id,National_no,Phone_no,training_Religion_id,training_Marital_Status_id,Address,training_Qualification_id,training_Qualification_university,training_Qualification_date,Start_date,end_date,Department_id,fingerprint_id")] trainings trainings)
        {
            if (ModelState.IsValid)
            {
                db.trainings.Add(trainings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country_id = new SelectList(db.Countries, "Country_id", "Country_name", trainings.Country_id);
            ViewBag.Department_id = new SelectList(db.Departments, "Department_id", "Department_name", trainings.Department_id);
            ViewBag.training_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name", trainings.training_Marital_Status_id);
            ViewBag.training_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", trainings.training_Qualification_id);
            ViewBag.training_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name", trainings.training_Religion_id);
            return View(trainings);
        }

        // GET: /Trinings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            trainings trainings = db.trainings.Find(id);
            if (trainings == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Country_id = new SelectList(db.Countries, "Country_id", "Country_name", trainings.Country_id);
            ViewBag.Department_id = new SelectList(db.Departments, "Department_id", "Department_name", trainings.Department_id);
            ViewBag.training_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name", trainings.training_Marital_Status_id);
            ViewBag.training_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", trainings.training_Qualification_id);
            ViewBag.training_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name", trainings.training_Religion_id);
            return View(trainings);
        }

        // POST: /Trinings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="training_id,training_name,Date_of_birth,Country_id,National_no,Phone_no,training_Religion_id,training_Marital_Status_id,Address,training_Qualification_id,training_Qualification_university,training_Qualification_date,Start_date,end_date,Department_id,fingerprint_id")] trainings trainings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country_id = new SelectList(db.Countries, "Country_id", "Country_name", trainings.Country_id);
            ViewBag.Department_id = new SelectList(db.Departments, "Department_id", "Department_name", trainings.Department_id);
            ViewBag.training_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name", trainings.training_Marital_Status_id);
            ViewBag.training_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", trainings.training_Qualification_id);
            ViewBag.training_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name", trainings.training_Religion_id);
            return View(trainings);
        }

        // GET: /Trinings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            trainings trainings = db.trainings.Find(id);
            if (trainings == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(trainings);
        }

        // POST: /Trinings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trainings trainings = db.trainings.Find(id);
            db.trainings.Remove(trainings);
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
