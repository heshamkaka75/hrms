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
    public class EmployeesController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Employees/
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Countries).Include(e => e.Departments).Include(e => e.fingerprints).Include(e => e.Genders).Include(e => e.Qualifications).Include(e => e.Jobs).Include(e => e.Marital_Status).Include(e => e.National_services_status).Include(e => e.Qualifications1).Include(e => e.ranks).Include(e => e.Religions);
            return View(employees.ToList());
        }

        // GET: /Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(employees);
        }

        // GET: /Employees/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Country_id = new SelectList(db.Countries, "Country_id", "Country_name");
            ViewBag.Employee_Department_id = new SelectList(db.Departments, "Department_id", "Department_name");
            ViewBag.Employee_fingerprint_id = new SelectList(db.fingerprints, "fingerprint_id", "national_ser_id");
            ViewBag.Employee_gender_id = new SelectList(db.Genders, "Gender_id", "Gender_name");
            ViewBag.Employee_high_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name");
            ViewBag.Employee_Job_id = new SelectList(db.Jobs, "job_id", "job_title");
            ViewBag.Employee_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name");
            ViewBag.Employee_national_services_status_id = new SelectList(db.National_services_status, "National_services_status_id", "National_services_status_name");
            ViewBag.Employee_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name");
            ViewBag.Employee_Rank_id = new SelectList(db.ranks, "rank_id", "rank_name");
            ViewBag.Employee_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name");
            return View();
        }

        // POST: /Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Employee_id,Employee_name,Mother_name,Date_of_birth,Employee_Country_id,National_no,Phone_no,Employee_Religion_id,Employee_Marital_Status_id,Employee_Qualification_id,Employee_Qualification_university,Employee_Qualification_date,Employee_high_Qualification_id,Employee_high_Qualification_university,Employee_high_Qualification_date,Address,Hire_date,Employee_national_services_status_id,Experiences_years,Employee_Job_id,Employee_Rank_id,Employee_Department_id,Employee_fingerprint_id,Employee_gender_id")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Country_id = new SelectList(db.Countries, "Country_id", "Country_name", employees.Employee_Country_id);
            ViewBag.Employee_Department_id = new SelectList(db.Departments, "Department_id", "Department_name", employees.Employee_Department_id);
            ViewBag.Employee_fingerprint_id = new SelectList(db.fingerprints, "fingerprint_id", "national_ser_id", employees.Employee_fingerprint_id);
            ViewBag.Employee_gender_id = new SelectList(db.Genders, "Gender_id", "Gender_name", employees.Employee_gender_id);
            ViewBag.Employee_high_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", employees.Employee_high_Qualification_id);
            ViewBag.Employee_Job_id = new SelectList(db.Jobs, "job_id", "job_title", employees.Employee_Job_id);
            ViewBag.Employee_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name", employees.Employee_Marital_Status_id);
            ViewBag.Employee_national_services_status_id = new SelectList(db.National_services_status, "National_services_status_id", "National_services_status_name", employees.Employee_national_services_status_id);
            ViewBag.Employee_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", employees.Employee_Qualification_id);
            ViewBag.Employee_Rank_id = new SelectList(db.ranks, "rank_id", "rank_name", employees.Employee_Rank_id);
            ViewBag.Employee_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name", employees.Employee_Religion_id);
            return View(employees);
        }

        // GET: /Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Employee_Country_id = new SelectList(db.Countries, "Country_id", "Country_name", employees.Employee_Country_id);
            ViewBag.Employee_Department_id = new SelectList(db.Departments, "Department_id", "Department_name", employees.Employee_Department_id);
            ViewBag.Employee_fingerprint_id = new SelectList(db.fingerprints, "fingerprint_id", "national_ser_id", employees.Employee_fingerprint_id);
            ViewBag.Employee_gender_id = new SelectList(db.Genders, "Gender_id", "Gender_name", employees.Employee_gender_id);
            ViewBag.Employee_high_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", employees.Employee_high_Qualification_id);
            ViewBag.Employee_Job_id = new SelectList(db.Jobs, "job_id", "job_title", employees.Employee_Job_id);
            ViewBag.Employee_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name", employees.Employee_Marital_Status_id);
            ViewBag.Employee_national_services_status_id = new SelectList(db.National_services_status, "National_services_status_id", "National_services_status_name", employees.Employee_national_services_status_id);
            ViewBag.Employee_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", employees.Employee_Qualification_id);
            ViewBag.Employee_Rank_id = new SelectList(db.ranks, "rank_id", "rank_name", employees.Employee_Rank_id);
            ViewBag.Employee_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name", employees.Employee_Religion_id);
            return View(employees);
        }

        // POST: /Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Employee_id,Employee_name,Mother_name,Date_of_birth,Employee_Country_id,National_no,Phone_no,Employee_Religion_id,Employee_Marital_Status_id,Employee_Qualification_id,Employee_Qualification_university,Employee_Qualification_date,Employee_high_Qualification_id,Employee_high_Qualification_university,Employee_high_Qualification_date,Address,Hire_date,Employee_national_services_status_id,Experiences_years,Employee_Job_id,Employee_Rank_id,Employee_Department_id,Employee_fingerprint_id,Employee_gender_id")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Country_id = new SelectList(db.Countries, "Country_id", "Country_name", employees.Employee_Country_id);
            ViewBag.Employee_Department_id = new SelectList(db.Departments, "Department_id", "Department_name", employees.Employee_Department_id);
            ViewBag.Employee_fingerprint_id = new SelectList(db.fingerprints, "fingerprint_id", "national_ser_id", employees.Employee_fingerprint_id);
            ViewBag.Employee_gender_id = new SelectList(db.Genders, "Gender_id", "Gender_name", employees.Employee_gender_id);
            ViewBag.Employee_high_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", employees.Employee_high_Qualification_id);
            ViewBag.Employee_Job_id = new SelectList(db.Jobs, "job_id", "job_title", employees.Employee_Job_id);
            ViewBag.Employee_Marital_Status_id = new SelectList(db.Marital_Status, "Marital_Status_id", "Marital_Status_name", employees.Employee_Marital_Status_id);
            ViewBag.Employee_national_services_status_id = new SelectList(db.National_services_status, "National_services_status_id", "National_services_status_name", employees.Employee_national_services_status_id);
            ViewBag.Employee_Qualification_id = new SelectList(db.Qualifications, "Qualification_id", "Qualification_name", employees.Employee_Qualification_id);
            ViewBag.Employee_Rank_id = new SelectList(db.ranks, "rank_id", "rank_name", employees.Employee_Rank_id);
            ViewBag.Employee_Religion_id = new SelectList(db.Religions, "Religion_id", "Religion_name", employees.Employee_Religion_id);
            return View(employees);
        }

        // GET: /Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(employees);
        }

        // POST: /Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
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
