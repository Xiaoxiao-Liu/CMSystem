using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CMSystem.Attribute;
using System.Security.Claims;
using System.Diagnostics;

namespace CMSystem.Controllers
{
    [Authorize(Roles = "Member, Customer")]
    [ClaimsAuthorize(ClaimTypes.Role, "Member, Customer")]
    public class AnnouncementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Announcement

        public ActionResult Index()
        {
            return View();
        }

        //Return a list of annoucement objects with the annoucing time earlier than today,
        //and with expiry time later than today.
        private IEnumerable<Announcement> GetAnnouncement()
        {
            return db.Announcement.ToList()
                 .Where(time => time.ExpiryTime >= DateTime.Today)
                .Where(time => time.AnnoucingTime <= DateTime.Today);
        }

        //Return a partial view.
        public ActionResult BuildAnnouncementTable()
        {
            return PartialView("_AnnouncementTable", GetAnnouncement());
        }

        // GET: Announcement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcement.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // GET: Announcement/Create
        [Authorize(Roles = "Member")]
        [ClaimsAuthorize(ClaimTypes.Role, "Member")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Announcement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Receive all data from ajax in "~/Views/Announcement/Index.cshtml" and add these data in database, 
        //then return a partial view with new data updated. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        [ClaimsAuthorize(ClaimTypes.Role, "Member")]
        public ActionResult AJAXCreate([Bind(Include = "AnnouncementId,AnnouncementTitle,AnnouncementContent,AnnoucingTime,ExpiryTime")] Announcement announcement)
        {
            Debug.WriteLine(announcement.AnnouncementTitle);
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == currentUserId);
            announcement.User = currentUser;
            announcement.Role = 0;
            db.Announcement.Add(announcement);
            Comment comment = new Comment();
            comment.Announcement = announcement;
            db.SaveChanges();
            Debug.WriteLine(GetAnnouncement());
            return PartialView("_AnnouncementTable", GetAnnouncement());
        }

        // GET: Announcement/Edit/5
        [Authorize(Roles = "Member")]
        [ClaimsAuthorize(ClaimTypes.Role, "Member")]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcement.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: Announcement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnnouncementId,AnnouncementTitle,AnnouncementContent,AnnoucingTime,ExpiryTime,Role")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {

                db.Entry(announcement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        // GET: Announcement/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcement.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: Announcement/Delete/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Get the id of an annoucement object, delete all announcement data from database and save changes,
        //then return a partial view with new data updated. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        [ClaimsAuthorize(ClaimTypes.Role, "Member")]
        public ActionResult AJAXDeleteConfirmed(int id)
        {
            Announcement announcement = db.Announcement.Find(id);
            db.Comment.RemoveRange(db.Comment.Where(x => x.Announcement.AnnouncementId == id));
            db.Announcement.Remove(announcement);
            db.SaveChanges();
            return PartialView("_AnnouncementTable", GetAnnouncement());
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
