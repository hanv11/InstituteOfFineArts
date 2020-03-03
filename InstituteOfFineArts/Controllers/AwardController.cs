using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Models;
using PagedList;

namespace InstituteOfFineArts.Controllers
{
    public class AwardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Award
        public ActionResult Index(int? page, int? awardtype)
        {
            var awards = db.Awards.Where(s => s.AwardName != Award.AwardType.none);
            int pageSize = 8;
            var pageNumber = page ?? 1;
            if (awardtype != null)
            {
                awards = awards.Where(a => (int)a.AwardName == awardtype);
                ViewBag.Awardtype = awardtype;
            }

           
            return View(awards.OrderBy(s => s.AwardName).ToPagedList(pageNumber, pageSize));
        }
        
        // GET: Award/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
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
