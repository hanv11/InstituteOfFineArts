using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Models;
using Microsoft.AspNet.Identity;

namespace InstituteOfFineArts.Areas.Teacher.Controllers
{
    public class AwardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teacher/Award
        public ActionResult Index()
        {
            return View(db.Awards.ToList());
        }

        // GET: Teacher/Award/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // GET: Teacher/Award/Create
        public ActionResult Create(int? submissionId)
        {
            if (submissionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var currentUserId = User.Identity.GetUserId();
            var account = db.Users.Find(currentUserId);
            var submission = db.Submissions.Find(submissionId);
            if (submission == null)
            {
                return HttpNotFound();
            }
            if (!submission.Competition.Creator.Equals(account))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            ViewBag.SubmissionId = submissionId;
            ViewBag.SubmissionName = submission.SubmissionName;
            ViewBag.Picture = submission.Picture;
            ViewBag.StudentName = submission.Account.FirstName + " " + submission.Account.LastName;
            return View();
        }


        // POST: Teacher/Award/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubmissionId,AwardName")] Award award)
        {
            if (ModelState.IsValid)
            {
                var CompetitionId = db.Competitions.First().CompetitionId;

                db.Awards.Add(award);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(award);
        }

        // GET: Teacher/Award/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // POST: Teacher/Award/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubmissionId,AwardName")] Award award)
        {
            if (ModelState.IsValid)
            {
                db.Entry(award).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(award);
        }

        // GET: Teacher/Award/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // POST: Teacher/Award/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Award award = db.Awards.Find(id);
            db.Awards.Remove(award);
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
