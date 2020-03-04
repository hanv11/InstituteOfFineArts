using InstituteOfFineArts.Areas.Teacher.Models;
using InstituteOfFineArts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteOfFineArts.Areas.Teacher.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var dashboard = new Dashboard
            {
                NumberOfStudent = db.Users.Count(u => u.UserType == Account.UserTypes.Student),
                NumberOfTeacher = db.Users.Count(u => u.UserType == Account.UserTypes.Teacher),
                NumberOfCompetition = db.Competitions.Count(),
                NumberOfCompetitionPending =
                    db.Competitions.Count(u => u.Status == Competition.CompetitionStatus.Pending),
                NumberOfSubmission = db.Submissions.Count()
            };
            return View(dashboard);
        }
    }
}