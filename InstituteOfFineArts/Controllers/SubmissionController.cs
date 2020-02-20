using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using InstituteOfFineArts.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace InstituteOfFineArts.Controllers
{
    public class SubmissionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Submissions
        public ActionResult Index()
        {
            var submissions = db.Submissions.Include(s => s.Competitions);
            return View(submissions.ToList());
        }
        public ActionResult ListSubmission(int? competitionId)
        {
            if (competitionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(competitionId);
            if (competition == null)
            {
                return HttpNotFound();
            }

            var submission = db.Submissions.Where(s => s.CompetitionId == competitionId);
            return PartialView("ListSubmission", submission.ToList().Take(4));
        }

        public ActionResult List(int? id, string searchString, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var submission = db.Submissions.Where(s => s.CompetitionId == id);
            if (!string.IsNullOrEmpty(searchString))
            {
                submission = submission.Where(s => s.SubmissionId.ToString().Contains(searchString));
            }
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            switch (sortOrder)
            {
                case "name_desc":
                    submission = submission.OrderByDescending(s => s.AccountId);
                    break;
                case "Date":
                    break;
                default:
                    submission = submission.OrderBy(s => s.AccountId.ToString());
                    break;
            }
            int pageSize = 4;
            var pageNumber = page ?? 1;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View("List", submission.ToPagedList(pageNumber, pageSize));
        }
        // GET: Submissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submission submission = db.Submissions.Find(id);
            if (submission == null)
            {
                return HttpNotFound();
            }
            return View(submission);
        }

        // GET: Submissions/Register
        [Authorize(Roles = "Student")]
        public ActionResult Register(int? competitionId)
        {
            if (competitionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(competitionId);
            if (competition == null)
            {
                return HttpNotFound();
            }

            return View(competition);
        }
        public ActionResult RegisterPartialView(int competitionId)
        {
            ViewBag.competitionId = competitionId;
            return PartialView();
        }
        // POST: Submissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student")]
        public ActionResult Create([Bind(Include = "CompetitionId,Picture,AccountId,Description")] Submission submission)
        {
            if (ModelState.IsValid)
            {
                submission.AccountId = User.Identity.GetUserId();
                db.Submissions.Add(submission);
                db.SaveChanges();
                return View("Details", submission);
            }


            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "CompetitionName", submission.CompetitionId);
            return View("Details", submission);
        }

        // GET: Submissions/Edit/5
        [Authorize(Roles = "Student")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submission submission = db.Submissions.Find(id);
            if (submission == null)
            {
                return HttpNotFound();
            }

            if (submission.AccountId == User.Identity.GetUserId())
            {
                ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "CompetitionName", submission.CompetitionId);

            }
            return View(submission);
        }

        // POST: Submissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Student")]
        public ActionResult Edit([Bind(Include = "SubmissionId,CompetitionId,Picture,AccountId,Description")] Submission submission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(submission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = submission.SubmissionId });
            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "CompetitionName", submission.CompetitionId);
            return View(submission);
        }

        // GET: Submissions/Delete/5
        [Authorize(Roles = "Admin,Teacher")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submission submission = db.Submissions.Find(id);
            if (submission == null)
            {
                return HttpNotFound();
            }
            return View(submission);
        }

        [Authorize(Roles = "Admin,Teacher")]
        // POST: Submissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Submission submission = db.Submissions.Find(id);
            db.Submissions.Remove(submission);
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
