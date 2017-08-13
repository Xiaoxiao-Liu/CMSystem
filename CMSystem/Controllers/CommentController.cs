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
using System.Diagnostics;
using CMSystem.Attribute;
using System.Security.Claims;

namespace CMSystem.Controllers
{
    [Authorize(Roles = "Member, Customer")]
    [ClaimsAuthorize(ClaimTypes.Role, "Member, Customer")]
    public class CommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<Comment> GetComment(Announcement Announcement)
        {
            IEnumerable<Comment> myComment = db.Comment.Where(x => x.Announcement.AnnouncementId == Announcement.AnnouncementId).ToList();
            int countComment = 0;
            foreach (Comment comment in myComment)
            {
                countComment++;
            }

            ViewData["CommentNumber"] = countComment;

            return myComment;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuildCommentTable(int announcementId)
        {
            Announcement Announcement = db.Announcement.FirstOrDefault
         (x => x.AnnouncementId == announcementId);
            return PartialView("_CommentTable", GetComment(Announcement));
        }

        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,CommentContent,Anonymous")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currentUserId);
                comment.User = currentUser;
                comment.CommentTime = DateTime.Now;

                db.Comment.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXCreate(Comment commentModels, int announcementId)
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == currentUserId);
            commentModels.User = currentUser;
            Announcement Announcement = db.Announcement.FirstOrDefault
                    (x => x.AnnouncementId == announcementId);
            commentModels.Announcement = Announcement;
            commentModels.CommentTime = DateTime.Now;
            db.Comment.Add(commentModels);
            db.SaveChanges();
            return PartialView("_CommentTable", GetComment(Announcement));
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,CommentContent,Anonymous,CommentTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comment.Find(id);
            db.Comment.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult AJAXDeleteConfirmed(int id)
        {
            
            Comment comment = db.Comment.Find(id);
            Announcement annoucement = comment.Announcement;
            db.Comment.Remove(comment);
            db.SaveChanges();
            return PartialView("_CommentTable", GetComment(annoucement));
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
