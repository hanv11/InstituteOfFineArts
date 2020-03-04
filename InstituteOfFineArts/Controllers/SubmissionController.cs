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
            var submissions = db.Submissions.Include(s => s.Competition);
            return View(submissions.ToList());
        }
        public ActionResult SubmissionIndex()
        {
            var submissions = db.Submissions.Include(s => s.Competition).Where(s => s.Status == Submission.SubmissionStatus.Confirmed);
            return PartialView(submissions.ToList().Take(4));
        }
        public ActionResult ListSubmission(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(Id);
            if (competition == null || competition.Status == Competition.CompetitionStatus.Cancel || competition.Status == Competition.CompetitionStatus.Pending)
            {
                return HttpNotFound();
            }

            var submission = db.Submissions.Where(s => s.CompetitionId == Id & s.Status == Submission.SubmissionStatus.Confirmed);
            return PartialView("ListSubmission", submission.ToList().Take(3));
        }
        public ActionResult SomeSubmission(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(Id);
            if (competition == null || competition.Status == Competition.CompetitionStatus.Cancel || competition.Status == Competition.CompetitionStatus.Pending)
            {
                return HttpNotFound();
            }

            var submission = db.Submissions.Where(s => s.CompetitionId == Id);
            return PartialView("SomeSubmission", submission.ToList().Take(3));
        }

        public ActionResult List(int? id, string searchString, string sortOrder, string currentFilter, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var submission = db.Submissions.Where(s => s.CompetitionId == id && s.Status == Submission.SubmissionStatus.Confirmed);
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
                    submission = submission.OrderByDescending(s => s.CreatorId);
                    break;
                case "Date":
                    break;
                default:
                    submission = submission.OrderBy(s => s.CreatorId.ToString());
                    break;
            }
            int pageSize = 8;
            var pageNumber = page ?? 1;
            return View("List", submission.ToPagedList(pageNumber, pageSize));
        }
        // [Authorize(Roles = "Student")]
        // GET: Submissions/Details/5
        public ActionResult Details(int? id)
        {
            var currentUserId = User.Identity.GetUserId();
            var user = db.Users.Find(currentUserId);
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
        public ActionResult Register(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var currentUserId = User.Identity.GetUserId();
            var user = db.Users.Find(currentUserId);
            Competition competition = db.Competitions.Find(id);
            if (competition == null || competition.StartDate > DateTime.Now || competition.EndDate < DateTime.Now)
            {
                return HttpNotFound();
            }
            if ( competition.Participants.Contains(user))
            {
                var submission = competition.Submissions.FirstOrDefault(s => s.CreatorId == currentUserId);
                if (submission != null) RedirectToAction("Details", new {id = submission.SubmissionId});
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
        public ActionResult Create([Bind(Include = "CompetitionId,Picture,AccountId,Description,SubmissionName,UpdatedAt")] Submission submission)
        {
            if (ModelState.IsValid)
            {
                var competition = db.Competitions.Find(submission.CompetitionId);
                if (competition.Participants.Contains(submission.Creator) || competition.StartDate.Date >= DateTime.Now || competition.EndDate.Date <= DateTime.Now)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var userId = User.Identity.GetUserId();
                var account = db.Users.Find(userId);
                var submissions = db.Submissions.Where(s => s.CreatorId == userId && s.CompetitionId == submission.CompetitionId);
                if (submissions.Any())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                submission.CreatorId = User.Identity.GetUserId();
                submission.Creator = account;
                submission.CreatedAt = DateTime.Now;
                submission.UpdatedAt = DateTime.Now;
                db.Submissions.Add(submission);
                db.SaveChanges();
                return RedirectToAction("Details", new {id= submission.SubmissionId});
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
            var submission = db.Submissions.Find(id);
            if (submission == null)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();
            if (!submission.CreatorId.Equals(userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            if (submission.CreatorId == User.Identity.GetUserId())
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
        public ActionResult Edit([Bind(Include = "SubmissionId,CompetitionId,Picture,CreatorId,Description, SubmissionName")] Submission submission)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var account = db.Users.Find(userId);
                if (submission.CreatorId != userId)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }
                db.Entry(submission).State = EntityState.Modified;
                submission.CreatorId = userId;
                submission.Creator = account;
                submission.UpdatedAt = DateTime.Now;
                submission.Status = Submission.SubmissionStatus.Pending;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = submission.SubmissionId });
            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "CompetitionName", submission.CompetitionId);
            return View(submission);
        }

        // GET: Submissions/Delete/5
        [Authorize(Roles = "Admin,Teacher,Student")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var submission = db.Submissions.Find(id);
            if (submission == null)
            {
                return HttpNotFound();
            }
            return View(submission);
        }

        [Authorize(Roles = "Admin,Teacher,Student")]
        // POST: Submissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var submission = db.Submissions.Find(id);
            if (submission == null)
            {
                return HttpNotFound();
            }
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
