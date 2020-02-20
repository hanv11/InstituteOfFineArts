using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteOfFineArts.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin,Teacher,Manager")]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}