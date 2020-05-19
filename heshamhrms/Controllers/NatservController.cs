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
    public class NatservController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Natserv/
        public ActionResult Index()
        {
            var national_services = db.national_services.Include(n => n.Countries).Include(n => n.Departments).Include(n => n.fingerprints).Include(n => n.Marital_Status).Include(n => n.Qualifications).Include(n => n.Religions);
            return View(national_services.ToList());
        }

        // GET: /Natserv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            national_services national_services = db.national_services.Find(id);
            if (national_services == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(national_services);
        }

        // GET: /Natserv/Create
        public ActionResult Create()
        {
            ViewBag.Country_id = new SelectList(db.Countries, "Country_id", "Country_name");
            ViewBag.Department_id = new SelectList(db.Departments, "Department_id", "Department_name");
            ViewBag.fingerprint_id = new SelectList(db.fingerprints, "fingerprint_id", "national_ser_id");
            ViewBag.National_services_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name");
            ViewBag.national_service_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name");
            ViewBag.National_services_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name");
            return View();
        }

        // POST: /Natserv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="national_service_id,national_service_name,Date_of_birth,Country_id,National_no,Phone_no,National_services_Religion_id,National_services_Marital_Status_id,Address,national_service_Qualification_id,national_service_Qualification_university,national_service_Qualification_date,start_date,End_date,Department_id,fingerprint_id")] national_services national_services)
        {
            if (ModelState.IsValid)
            {
                db.national_services.Add(national_services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country_id = new SelectList(db.Countries, "Country_id", "Country_name", national_services.Country_id);
            ViewBag.Department_id = new SelectList(db.Departments, "Department_id", "Department_name", national_services.Department_id);
            ViewBag.fingerprint_id = new SelectList(db.fingerprints, "fingerprint_id", "national_ser_id", national_services.fingerprint_id);
            ViewBag.National_services_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name", national_services.National_services_Marital_Status_id);
            ViewBag.national_service_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", national_services.national_service_Qualification_id);
            ViewBag.National_services_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name", national_services.National_services_Religion_id);
            return View(national_services);
        }

        // GET: /Natserv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            national_services national_services = db.national_services.Find(id);
            if (national_services == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Country_id = new SelectList(db.Countries, "Country_id", "Country_name", national_services.Country_id);
            ViewBag.Department_id = new SelectList(db.Departments, "Department_id", "Department_name", national_services.Department_id);
            ViewBag.fingerprint_id = new SelectList(db.fingerprints, "fingerprint_id", "national_ser_id", national_services.fingerprint_id);
            ViewBag.National_services_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name", national_services.National_services_Marital_Status_id);
            ViewBag.national_service_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", national_services.national_service_Qualification_id);
            ViewBag.National_services_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name", national_services.National_services_Religion_id);
            return View(national_services);
        }

        // POST: /Natserv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="national_service_id,national_service_name,Date_of_birth,Country_id,National_no,Phone_no,National_services_Religion_id,National_services_Marital_Status_id,Address,national_service_Qualification_id,national_service_Qualification_university,national_service_Qualification_date,start_date,End_date,Department_id,fingerprint_id")] national_services national_services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(national_services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country_id = new SelectList(db.Countries, "Country_id", "Country_name", national_services.Country_id);
            ViewBag.Department_id = new SelectList(db.Departments, "Department_id", "Department_name", national_services.Department_id);
            ViewBag.fingerprint_id = new SelectList(db.fingerprints, "fingerprint_id", "national_ser_id", national_services.fingerprint_id);
            ViewBag.National_services_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name", national_services.National_services_Marital_Status_id);
            ViewBag.national_service_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", national_services.national_service_Qualification_id);
            ViewBag.National_services_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name", national_services.National_services_Religion_id);
            return View(national_services);
        }

        // GET: /Natserv/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            national_services national_services = db.national_services.Find(id);
            if (national_services == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(national_services);
        }

        // POST: /Natserv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            national_services national_services = db.national_services.Find(id);
            db.national_services.Remove(national_services);
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
