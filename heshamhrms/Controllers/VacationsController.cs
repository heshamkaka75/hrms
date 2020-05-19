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
    public class VacationsController : Controller
    {
        private hrmsEntities db = new hrmsEntities();

        // GET: /Vacations/
        public ActionResult Index()
        {
            var vacations = db.Vacations.Include(v => v.Departments).Include(v => v.Employees).Include(v => v.Users).Include(v => v.Vacations_type);
            return View(vacations.ToList());
        }

        // GET: /Vacations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Vacations vacations = db.Vacations.Find(id);
            if (vacations == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(vacations);
        }

        // GET: /Vacations/Create
        public ActionResult Create()
        {
            ViewBag.Vacation_depatrments_id = new SelectList(db.Departments.OrderBy(item => item.Department_name), "Department_id", "Department_name");
            ViewBag.Vacation_employee_name = new SelectList(db.Employees.OrderBy(item => item.Employee_name), "Employee_id", "Employee_name");
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            ViewBag.Vacation_vt_id = new SelectList(db.Vacations_type, "Vacation_type_id", "Vacation_name");
            return View();
        }

        // POST: /Vacations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Vacation_id,Vacation_employee_name,Vacation_vt_id,Vacation_depatrments_id,Vacation_duration,Vacation_start_date,Vacation_end_date,Vacation_Reason,Edit_by,Date_time")] Vacations vacations)
        {
            if (ModelState.IsValid)
            {
                db.Vacations.Add(vacations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vacation_depatrments_id = new SelectList(db.Departments, "Department_id", "Department_name", vacations.Vacation_depatrments_id);
            ViewBag.Vacation_employee_name = new SelectList(db.Employees, "Employee_id", "Employee_name", vacations.Vacation_employee_name);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", vacations.Edit_by);
            ViewBag.Vacation_vt_id = new SelectList(db.Vacations_type, "Vacation_type_id", "Vacation_name", vacations.Vacation_vt_id);
            return View(vacations);
        }

        // GET: /Vacations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Vacations vacations = db.Vacations.Find(id);
            if (vacations == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Vacation_depatrments_id = new SelectList(db.Departments, "Department_id", "Department_name", vacations.Vacation_depatrments_id);
            ViewBag.Vacation_employee_name = new SelectList(db.Employees, "Employee_id", "Employee_name", vacations.Vacation_employee_name);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", vacations.Edit_by);
            ViewBag.Vacation_vt_id = new SelectList(db.Vacations_type, "Vacation_type_id", "Vacation_name", vacations.Vacation_vt_id);
            return View(vacations);
        }

        // POST: /Vacations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Vacation_id,Vacation_employee_name,Vacation_vt_id,Vacation_depatrments_id,Vacation_duration,Vacation_start_date,Vacation_end_date,Vacation_Reason,Edit_by,Date_time")] Vacations vacations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vacation_depatrments_id = new SelectList(db.Departments, "Department_id", "Department_name", vacations.Vacation_depatrments_id);
            ViewBag.Vacation_employee_name = new SelectList(db.Employees, "Employee_id", "Employee_name", vacations.Vacation_employee_name);
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name", vacations.Edit_by);
            ViewBag.Vacation_vt_id = new SelectList(db.Vacations_type, "Vacation_type_id", "Vacation_name", vacations.Vacation_vt_id);
            return View(vacations);
        }



        public ActionResult Emp()
        {
            var emp = db.Employees.Include(v => v.Departments);
            return View(emp.ToList());
        }

        public ActionResult Empdt(int? id)
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
            #region 19

            // annally
            var annually19 = (from vb in db.Vacation_Balances
                              where vb.Vb_vt_id == 2
                              where vb.vb_emp_id == id
                              select vb.vb_total).FirstOrDefault();
            ViewBag.ann19 = annually19;

            var restannually19 = (from v in db.Vacations
                                  where v.Vacation_employee_name == id
                                  where v.Vacation_vt_id == 2
                                  select v.Vacation_duration).Sum();
            var restan19 = annually19 - restannually19;
            ViewBag.restann19 = restan19;

            //local

            var local19 = (from vb in db.Vacation_Balances
                              where vb.Vb_vt_id == 1
                              where vb.vb_emp_id == id
                              select vb.vb_total).FirstOrDefault();
            ViewBag.loc19 = local19;

            var restlocal19 = (from v in db.Vacations
                                  where v.Vacation_employee_name == id
                                  where v.Vacation_vt_id == 1
                                  select v.Vacation_duration).Sum();
            var restloc19 = local19 - restlocal19;
            ViewBag.restlo19 = restloc19;

            //no salary

            var nosalary19 = (from vb in db.Vacation_Balances
                              where vb.Vb_vt_id == 2
                              where vb.vb_emp_id == id
                              select vb.vb_total).FirstOrDefault();
            ViewBag.nosal19 = nosalary19;

            var restnosalary19 = (from v in db.Vacations
                                  where v.Vacation_employee_name == id
                                  where v.Vacation_vt_id == 2
                                  select v.Vacation_duration).Sum();
            var restnosala19 = nosalary19 - restnosalary19;
            ViewBag.restnosal19 = restnosala19;

            // hajj

            var hajj19 = (from vb in db.Vacation_Balances
                          where vb.Vb_vt_id == 2
                          where vb.vb_emp_id == id
                          select vb.vb_total).FirstOrDefault();
            ViewBag.haj19 = hajj19;

            var resthajj19 = (from v in db.Vacations
                              where v.Vacation_employee_name == id
                              where v.Vacation_vt_id == 2
                              select v.Vacation_duration).Sum();
            var resthaj19 = hajj19 - resthajj19;
            ViewBag.resthj19 = resthaj19;

            //baby

            var baby19 = (from vb in db.Vacation_Balances
                          where vb.Vb_vt_id == 2
                          where vb.vb_emp_id == id
                          select vb.vb_total).FirstOrDefault();
            ViewBag.bab19 = baby19;

            var restbaby19 = (from v in db.Vacations
                              where v.Vacation_employee_name == id
                              where v.Vacation_vt_id == 2
                              select v.Vacation_duration).Sum();
            var restbab19 = baby19 - restbaby19;
            ViewBag.restba19 = restbab19;



            #endregion

            #region 20

            // annually
            var annually20 = (from vb in db.Vacation_Balances
                              where vb.Vb_vt_id == 3
                              where vb.vb_emp_id == id
                              select vb.vb_total).FirstOrDefault();
            ViewBag.ann20 = annually20;

            var restannually20 = (from v in db.Vacations
                                  where v.Vacation_employee_name == id
                                  where v.Vacation_vt_id == 3
                                  select v.Vacation_duration).Sum();
            var restan20 = annually20 - restannually20;
            ViewBag.restann20 = restan20;

            //local


            var local20 = (from vb in db.Vacation_Balances
                           where vb.Vb_vt_id == 4
                           where vb.vb_emp_id == id
                           select vb.vb_total).FirstOrDefault();
            ViewBag.loc20 = local20;

            var restlocal20 = (from v in db.Vacations
                               where v.Vacation_employee_name == id
                               where v.Vacation_vt_id == 4
                               select v.Vacation_duration).Sum();
            var restloc20 = local20 - restlocal20;
            ViewBag.restlo20 = restloc20;


            //no salary

            var nosalary20 = (from vb in db.Vacation_Balances
                              where vb.Vb_vt_id == 2
                              where vb.vb_emp_id == id
                              select vb.vb_total).FirstOrDefault();
            ViewBag.nosal20 = nosalary20;

            var restnosalary20 = (from v in db.Vacations
                                  where v.Vacation_employee_name == id
                                  where v.Vacation_vt_id == 2
                                  select v.Vacation_duration).Sum();
            var restnosala20 = nosalary20 - restnosalary20;
            ViewBag.restnosal20 = restnosala20;

            // hajj

            var hajj20 = (from vb in db.Vacation_Balances
                          where vb.Vb_vt_id == 2
                          where vb.vb_emp_id == id
                          select vb.vb_total).FirstOrDefault();
            ViewBag.haj20 = hajj20;

            var resthajj20 = (from v in db.Vacations
                              where v.Vacation_employee_name == id
                              where v.Vacation_vt_id == 2
                              select v.Vacation_duration).Sum();
            var resthaj20 = hajj20 - resthajj20;
            ViewBag.resthj20 = resthaj20;

            //baby

            var baby20 = (from vb in db.Vacation_Balances
                          where vb.Vb_vt_id == 2
                          where vb.vb_emp_id == id
                          select vb.vb_total).FirstOrDefault();
            ViewBag.bab20 = baby20;

            var restbaby20 = (from v in db.Vacations
                              where v.Vacation_employee_name == id
                              where v.Vacation_vt_id == 2
                              select v.Vacation_duration).Sum();
            var restbab20 = baby20 - restbaby20;
            ViewBag.restba20 = restbab20;

            
            #endregion


            return View(employees);
        }

        public ActionResult Add(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Vacations vacations = db.Vacations.Find(id);
            if (vacations == null)
            {
                return Redirect("~/Login/Notfound");
            }
            ViewBag.Vacation_depatrments_id = new SelectList(db.Departments, "Department_id", "Department_name");
            ViewBag.Vacation_employee_name = new SelectList(db.Employees, "Employee_id", "Employee_name");
            ViewBag.Edit_by = new SelectList(db.Users, "User_id", "User_name");
            ViewBag.Vacation_vt_id = new SelectList(db.Vacations_type, "Vacation_type_id", "Vacation_name");
            return View();
        }

        // GET: /Vacations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("~/Login/Notfound");
            }
            Vacations vacations = db.Vacations.Find(id);
            if (vacations == null)
            {
                return Redirect("~/Login/Notfound");
            }
            return View(vacations);
        }

        // POST: /Vacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacations vacations = db.Vacations.Find(id);
            db.Vacations.Remove(vacations);
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
