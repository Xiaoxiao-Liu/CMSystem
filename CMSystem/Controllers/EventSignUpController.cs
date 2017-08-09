using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSystem.Models;

namespace CMSystem.Controllers
{
    public class EventSignUpController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventSignUp
        public ActionResult Index()
        {
            return View(db.EventSignUp.ToList());
        }

        // GET: EventSignUp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventSignUp eventSignUp = db.EventSignUp.Find(id);
            if (eventSignUp == null)
            {
                return HttpNotFound();
            }
            return View(eventSignUp);
        }

        // GET: EventSignUp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventSignUp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventSignUpId,SignUpTime")] EventSignUp eventSignUp)
        {
            if (ModelState.IsValid)
            {
                db.EventSignUp.Add(eventSignUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventSignUp);
        }

        // GET: EventSignUp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventSignUp eventSignUp = db.EventSignUp.Find(id);
            if (eventSignUp == null)
            {
                return HttpNotFound();
            }
            return View(eventSignUp);
        }

        // POST: EventSignUp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventSignUpId,SignUpTime")] EventSignUp eventSignUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventSignUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventSignUp);
        }

        // GET: EventSignUp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventSignUp eventSignUp = db.EventSignUp.Find(id);
            if (eventSignUp == null)
            {
                return HttpNotFound();
            }
            return View(eventSignUp);
        }

        // POST: EventSignUp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventSignUp eventSignUp = db.EventSignUp.Find(id);
            db.EventSignUp.Remove(eventSignUp);
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
