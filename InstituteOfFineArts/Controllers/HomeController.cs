using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Models;

namespace InstituteOfFineArts.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult NewSubmission()
        {
            var submission = db.Submissions.Where(s => s.Status == Submission.SubmissionStatus.Confirmed).OrderBy(s => s.CreatedAt).Take(10);
            return PartialView("_NewSubmission", submission );
        }
        public ActionResult ExhibitionGallery()
        {
            var submission = db.Submissions.Where(s => s.Status == Submission.SubmissionStatus.Confirmed).OrderBy(s => s.CreatedAt).Take(12);
            return PartialView("_ExhibitionGallery", submission);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListCompetition()
        {
            var competitions = db.Competitions.Where(c => c.Status != Competition.CompetitionStatus.Cancel).OrderBy(x => x.CancelAt).ToList();
            return PartialView("_ListCompetition", competitions);
        }

        public ActionResult SlideBar()
        {
            var competitions = db.Competitions.Where(c => c.Status != Competition.CompetitionStatus.Cancel && c.IsSlide).OrderBy(c => c.CancelAt).Take(3).ToList();
            return PartialView("_SlideBar", competitions);
        }
        
    }
}