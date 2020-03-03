using InstituteOfFineArts.Areas.Admin.Models;
using InstituteOfFineArts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteOfFineArts.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Dashboard
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Index()
        {
            var dashboard = new Dashboard();
            dashboard.NumberOfStudent = db.Users.Count(u => u.UserType == Account.UserTypes.Student);
            dashboard.NumberOfTeacher = db.Users.Count(u => u.UserType == Account.UserTypes.Teacher);
            dashboard.NumberOfCompetition = db.Competitions.Count();
            dashboard.NumberOfCompetitionPending = db.Competitions.Count(u => u.Status == Competition.CompetitionStatus.Pending);
            dashboard.NumberOfSubmission = db.Submissions.Count();
            return View(dashboard);
        }
    }
}