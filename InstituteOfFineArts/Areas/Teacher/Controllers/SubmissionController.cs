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
using PagedList;

namespace InstituteOfFineArts.Areas.Teacher.Controllers
{
    public class SubmissionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teacher/Submission
        public ActionResult Index()
        {
            var submissions = db.Submissions.Include(s => s.Account).Include(s => s.Competition);
            return View(submissions.ToList());
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
            int pageSize = 8;
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
            return View("List",submission.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ListSubmission(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(Id);
            if (competition == null)
            {
                return HttpNotFound();
            }

            var submission = db.Submissions.Where(s => s.CompetitionId == Id);
            return View(submission.ToList());
        }
        // GET: Submissions/Edit/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Mark(int? id)
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

        [Authorize(Roles = "Teacher")]
        public ActionResult Mark([Bind(Include = "SubmissionId,CompetitionId,Picture,AccountId,Description")] Submission submission)
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

    }
}
