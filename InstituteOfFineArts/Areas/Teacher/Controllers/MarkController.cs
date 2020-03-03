using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Areas.Teacher.Models;
using InstituteOfFineArts.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace InstituteOfFineArts.Areas.Teacher.Controllers
{
    public class MarkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teacher/Mark
        public ActionResult Index()
        {
            var marks = db.Marks.Include(m => m.Examiner).Include(m => m.Submission);
            return View(marks.ToList());
            
           
        }

        // GET: Teacher/Mark/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // GET: Teacher/Mark/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create(int? submissionId)
        {
            if (submissionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var currentUserId = User.Identity.GetUserId();
            var account = db.Users.Find(currentUserId);
            var submission = db.Submissions.Find(submissionId);
            var competition = submission.CompetitionId;
            if (submission == null)
            {
                return HttpNotFound();
            }
            if (!submission.Competition.Examiners.Contains(account))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            ViewBag.SubmissionId = submissionId;
            ViewBag.Description = submission.Description;
            ViewBag.Picture = submission.Picture;
            ViewBag.SubmissionName = submission.SubmissionName;
            ViewBag.CompetitionId = competition;
            return View();
        }

        // POST: Teacher/Mark/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarkId,SubmissionId,AccountId,Marks,Description")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                var submission = db.Submissions.Find(mark.SubmissionId);
                var competition = submission.Competition;
                var teacherId = User.Identity.GetUserId();
                var account = db.Users.Find(teacherId);
                mark.AccountId = teacherId;
                mark.Examiner = account;
                db.Marks.Add(mark);
                db.SaveChanges();
                return RedirectToAction("ListMark",new {competitionId = competition.CompetitionId});
            }
            return View(mark);
        }

        // GET: Teacher/Mark/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Users, "Id", "FirstName", mark.AccountId);
            ViewBag.SubmissionId = new SelectList(db.Submissions, "SubmissionId", "Picture", mark.SubmissionId);
            return View(mark);
        }

        // POST: Teacher/Mark/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarkId,SubmissionId,AccountId,Marks,Description")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                var submission = db.Submissions.Find(mark.SubmissionId);
                var competition = submission.Competition;
                var teacherId = User.Identity.GetUserId();
                var account = db.Users.Find(teacherId);
                mark.AccountId = teacherId;
                mark.Examiner = account;
                db.Entry(mark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListMark", new { competitionId = competition.CompetitionId });
            }
            ViewBag.AccountId = new SelectList(db.Users, "Id", "FirstName", mark.AccountId);
            ViewBag.SubmissionId = new SelectList(db.Submissions, "SubmissionId", "Picture", mark.SubmissionId);
            return View(mark);
        }

        // GET: Teacher/Mark/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // POST: Teacher/Mark/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mark mark = db.Marks.Find(id);
            db.Marks.Remove(mark);
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

        public ActionResult ListMark(int? competitionId)
        {
            if (competitionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var competition = db.Competitions.Find(competitionId);

            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserId);

            if (competition == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            if (!competition.Examiners.Contains(currentUser))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var allSubmission = db.Submissions.Where(s => s.CompetitionId == competitionId);
            var markView = (from submission in db.Submissions
                join mark in db.Marks on submission.SubmissionId equals mark.SubmissionId
                where submission.CompetitionId == competitionId & mark.AccountId.Equals(currentUserId)
                select new MarkViewModel
                {
                    SubmissionId = submission.SubmissionId,
                    MarkId = mark.MarkId,
                    Image = submission.Picture,
                    Description = submission.Description,
                    Comment = mark.Description,
                    Mark = mark.Marks,
                    StudentName = submission.Creator.FirstName + " " + submission.Creator.LastName
                }).ToList();
            foreach (var item in allSubmission)
            {
                var mark = db.Marks.FirstOrDefault(m =>
                    m.AccountId.Equals(currentUserId) & m.SubmissionId == item.SubmissionId);
                if (mark == null)
                {
                    markView.Add(new MarkViewModel()
                    {
                        SubmissionId = item.SubmissionId,
                        MarkId = null,
                        Image = item.Picture,
                        Description = item.Description,
                        StudentName = item.Creator.FirstName + " " + item.Creator.LastName,
                    });
                }
            }

            return View(markView);
        }

    }
}
