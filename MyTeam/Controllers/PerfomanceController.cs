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
    public class PerfomanceController : Controller
    {
        private InitiumEmployeeDBEntities1 db = new InitiumEmployeeDBEntities1();

        // GET: Perfomance
        public ActionResult Index()
        {
            return View(db.Perfomances.ToList());
        }

        // GET: Perfomance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfomance perfomance = db.Perfomances.Find(id);
            if (perfomance == null)
            {
                return HttpNotFound();
            }
            return View(perfomance);
        }

        // GET: Perfomance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfomance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerformanceId,dateofreview,reviewedbyemployer,commentbyreviewer,commentbyemployee")] Perfomance perfomance)
        {
            if (ModelState.IsValid)
            {
                db.Perfomances.Add(perfomance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfomance);
        }

        // GET: Perfomance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfomance perfomance = db.Perfomances.Find(id);
            if (perfomance == null)
            {
                return HttpNotFound();
            }
            return View(perfomance);
        }

        // POST: Perfomance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerformanceId,dateofreview,reviewedbyemployer,commentbyreviewer,commentbyemployee")] Perfomance perfomance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfomance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfomance);
        }

        // GET: Perfomance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfomance perfomance = db.Perfomances.Find(id);
            if (perfomance == null)
            {
                return HttpNotFound();
            }
            return View(perfomance);
        }

        // POST: Perfomance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfomance perfomance = db.Perfomances.Find(id);
            db.Perfomances.Remove(perfomance);
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
