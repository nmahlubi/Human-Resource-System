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
    public class LeaveManagementsController : Controller
    {
        private InitiumEmployeeDBEntities1 db = new InitiumEmployeeDBEntities1();

        // GET: LeaveManagements
        public ActionResult Index()
        {
            return View(db.LeaveManagements.ToList());
        }

        // GET: LeaveManagements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveManagement leaveManagement = db.LeaveManagements.Find(id);
            if (leaveManagement == null)
            {
                return HttpNotFound();
            }
            return View(leaveManagement);
        }

        // GET: LeaveManagements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveManagements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "leaveManagementId,annual_leave,sick_leave,maternity_leave,start_date,end_date,total_day,comment,accept,decline,datecreated")] LeaveManagement leaveManagement)
        {
            if (ModelState.IsValid)
            {
                db.LeaveManagements.Add(leaveManagement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leaveManagement);
        }

        // GET: LeaveManagements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveManagement leaveManagement = db.LeaveManagements.Find(id);
            if (leaveManagement == null)
            {
                return HttpNotFound();
            }
            return View(leaveManagement);
        }

        // POST: LeaveManagements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "leaveManagementId,annual_leave,sick_leave,maternity_leave,start_date,end_date,total_day,comment,accept,decline,datecreated")] LeaveManagement leaveManagement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveManagement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leaveManagement);
        }

        // GET: LeaveManagements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveManagement leaveManagement = db.LeaveManagements.Find(id);
            if (leaveManagement == null)
            {
                return HttpNotFound();
            }
            return View(leaveManagement);
        }

        // POST: LeaveManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveManagement leaveManagement = db.LeaveManagements.Find(id);
            db.LeaveManagements.Remove(leaveManagement);
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
