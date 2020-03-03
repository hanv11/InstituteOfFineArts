using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Areas.Teacher.Models;
using InstituteOfFineArts.Models;
using Microsoft.AspNet.Identity;

namespace InstituteOfFineArts.Areas.Manager.Controllers
{
    public class MarkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        public ActionResult Index()
        {
            var marks = db.Marks.Include(m => m.Examiner).Include(m => m.Submission);
            return View(marks.ToList());
        }

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
