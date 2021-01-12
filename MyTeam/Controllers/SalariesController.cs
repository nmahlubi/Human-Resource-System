using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyTeam.Models;

namespace MyTeam.Controllers
{
    public class SalariesController : Controller
    {
        private InitiumEmployeeDBEntities1 db = new InitiumEmployeeDBEntities1();

        // GET: Salaries
        public ActionResult Index()
        {
            var salaries = db.Salaries.Include(s => s.Payroll).Include(s => s.User);
            return View(salaries.ToList());
        }

        // GET: Salaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // GET: Salaries/Create
        public ActionResult Create()
        {
            ViewBag.SalaryId = new SelectList(db.Payrolls, "PayrollId", "allowance");
            ViewBag.payroll_iId = new SelectList(db.Users, "UserId", "FirstName");
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalaryId,payroll_iId,salarycreateddate")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Salaries.Add(salary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SalaryId = new SelectList(db.Payrolls, "PayrollId", "allowance", salary.SalaryId);
            ViewBag.payroll_iId = new SelectList(db.Users, "UserId", "FirstName", salary.payroll_iId);
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalaryId = new SelectList(db.Payrolls, "PayrollId", "allowance", salary.SalaryId);
            ViewBag.payroll_iId = new SelectList(db.Users, "UserId", "FirstName", salary.payroll_iId);
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalaryId,payroll_iId,salarycreateddate")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalaryId = new SelectList(db.Payrolls, "PayrollId", "allowance", salary.SalaryId);
            ViewBag.payroll_iId = new SelectList(db.Users, "UserId", "FirstName", salary.payroll_iId);
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salary salary = db.Salaries.Find(id);
            db.Salaries.Remove(salary);
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
