using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;

namespace InstituteOfFineArts.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class MemberController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public MemberController()
        {
        }

        public MemberController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Admin/Member
        public ActionResult Index(int? id, string searchString, int? usertype, int? status, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.NameSortPara = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortPara = sortOrder == "Date" ? "date_desc" : "Date";
            var members = db.Users.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                members = members.Where(s => s.UserCode.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) || s.Email.Contains(searchString));
            }
            if (usertype != null)
            {
                members = members.Where(m => (int)m.UserType == usertype);
            }
            if (status != null)
            {
                members = members.Where(m => (int)m.Status == status);
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
                    members = members.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    break;
                default:
                    members = members.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 10;
            var pageNumber = page ?? 1;
            return View(members.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Member/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Account account = db.Users.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        public ActionResult ListStudent(int? id, string searchString, int? usertype, int? status, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.NameSortPara = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortPara = sortOrder == "Date" ? "date_desc" : "Date";
            var members = db.Users.Where(m => m.UserType == Account.UserTypes.Student);
            if (!string.IsNullOrEmpty(searchString))
            {
                members = members.Where(s => s.UserCode.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) || s.Email.Contains(searchString));
            }
            if (usertype != null)
            {
                members = members.Where(m => (int)m.UserType == usertype);
            }
            if (status != null)
            {
                members = members.Where(m => (int)m.Status == status);
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
                    members = members.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    break;
                default:
                    members = members.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 10;
            var pageNumber = page ?? 1;
            return View(members.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ListTeacher(int? id, string searchString, int? usertype, int? status, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.NameSortPara = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortPara = sortOrder == "Date" ? "date_desc" : "Date";
            var members = db.Users.Where(m => m.UserType == Account.UserTypes.Teacher);
            if (!string.IsNullOrEmpty(searchString))
            {
                members = members.Where(s => s.UserCode.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) || s.Email.Contains(searchString));
            }
            if (usertype != null)
            {
                members = members.Where(m => (int)m.UserType == usertype);
            }
            if (status != null)
            {
                members = members.Where(m => (int)m.Status == status);
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
                    members = members.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    break;
                default:
                    members = members.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 10;
            var pageNumber = page ?? 1;
            return View(members.ToPagedList(pageNumber, pageSize));
        }

    }
}
