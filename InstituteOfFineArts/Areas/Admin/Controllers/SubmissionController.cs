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

namespace InstituteOfFineArts.Areas.Admin.Controllers
{
    public class SubmissionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teacher/Submission
        public ActionResult Index()
        {
            var submissions = db.Submissions.Include(s => s.Creator).Include(s => s.Competition);
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
    }
}
