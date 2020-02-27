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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListCompetition()
        {
            return PartialView("_ListCompetition", db.Competitions.ToList());
        }

        public ActionResult SlideBar()
        {
            var competitions = db.Competitions.Where(c => c.IsSlide).Take(5).ToList();
            return PartialView("_SlideBar", competitions);
        }
        
    }
}