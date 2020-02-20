using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Models;
using PagedList;

namespace InstituteOfFineArts.Areas.Admin.Controllers
{
    public class CompetitionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Competition
        public ActionResult Index(string searchString, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.NameSortPara = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortPara = sortOrder == "Date" ? "date_desc" : "Date";
            var competitions = db.Competitions.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                competitions = competitions.Where(s => s.CompetitionName.Contains(searchString));
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
                    competitions = competitions.OrderByDescending(s => s.CompetitionName);
                    break;
                case "Date":
                    break;
                default:
                    competitions = competitions.OrderBy(s => s.CompetitionName);
                    break;
            }
            int pageSize = 3;
            var pageNumber = page ?? 1;
            return View(competitions.ToPagedList(pageNumber, pageSize));
        }
    }
}