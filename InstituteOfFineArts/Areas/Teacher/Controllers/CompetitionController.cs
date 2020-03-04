using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Areas.Teacher.Models;
using InstituteOfFineArts.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;

namespace InstituteOfFineArts.Areas.Teacher.Controllers
{
    public class CompetitionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<Account> _userManager = new UserManager<Account>(new UserStore<Account>());
        // GET: Teacher/Competition
        [Authorize(Roles = "Teacher")]
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
            int pageSize = 4;
            var pageNumber = page ?? 1;
            return View(competitions.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetitionId,CompetitionName,StartDate,EndDate,Image,ShortDescription, AwardDetails,Description")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                competition.Status = Competition.CompetitionStatus.Pending;
                competition.CreatedAt = DateTime.Now;
                var currentUserId = User.Identity.GetUserId();
                var user = db.Users.Find(currentUserId);
                competition.CreatorId = currentUserId;
                competition.Creator = user;
                db.Competitions.Add(competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competition);
        }
        [Authorize(Roles = "Admin,Teacher")]
        // GET: Competitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            if (competition.CreatorId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            var model = new CompetitionViewModel()
            {
                CompetitionId =  competition.CompetitionId,
                CompetitionName =  competition.CompetitionName,
                StartDate =  competition.StartDate,
                EndDate = competition.EndDate,
                Image =  competition.Image,
                Description = competition.Description,
                ShortDescription = competition.ShortDescription
            };
            return View(model);
        }

        // POST: Competitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(CompetitionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var competition = db.Competitions.Find(model.CompetitionId);
                if (competition == null)
                {
                    return HttpNotFound();
                }
                db.Entry(competition).State = EntityState.Modified;
                competition.CompetitionName = competition.CompetitionName;
                competition.StartDate = competition.StartDate;
                competition.EndDate = competition.EndDate;
                competition.Image = competition.Image;
                competition.Description = competition.Description;
                competition.ShortDescription = competition.ShortDescription;
                competition.UpdatedAt = DateTime.Now;
                competition.CreatorId = User.Identity.GetUserId();
                db.SaveChanges();
                return RedirectToAction("MyCompetition");
            }
            return View(model);
        }
        [Authorize(Roles = "Teacher")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            if (competition.CreatorId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            competition.Status = Competition.CompetitionStatus.Cancel;
            competition.UpdatedAt = DateTime.Now;
            competition.CancelAt = DateTime.Now;
            return View(competition);
        }
        // POST: Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competition competition = db.Competitions.Find(id);
            db.Competitions.Remove(competition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetTeachers(string keyword)
        {
            var user = db.Users.Where(u =>
                u.UserType == Account.UserTypes.Teacher &
                (u.FirstName.Contains(keyword) | u.LastName.Contains(keyword))).Select( u=>new
                {
                    id = u.Id,
                    name = u.FirstName + u.LastName
                });

            return new JsonResult()
            {
                Data = user,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorize(Roles = "Teacher")]
        public ActionResult InviteExaminer(string accountId, int competitionId)
        {
            var account = db.Users.Find(accountId);
            var competition = db.Competitions.Find(competitionId);
            if (accountId == null)
            {
                return PartialView("_ListExaminer", competition.Examiners);
            }
            if (competition == null || competition.Examiners.Contains(account))
            {
                return null;
            }
            competition.Examiners.Add(account);
            db.SaveChanges();
            return PartialView("_ListExaminer", competition.Examiners);
        }
        [Authorize(Roles = "Teacher")]
        public ActionResult Joined()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserId);
            var competition = db.Competitions.Where(c => c.Examiners.Select(s => s.Id).Contains(currentUserId)).ToList();
            return View(competition);
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult MyCompetition(string searchString, string sortOrder, string currentFilter, int? page)
        {
            var currentUserId = User.Identity.GetUserId();
            ViewBag.NameSortPara = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.DateSortPara = sortOrder == "Date" ? "date_desc" : "Date";
                var competitions = db.Competitions.Where(c => c.CreatorId.Equals(currentUserId));
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
                int pageSize = 5;
                var pageNumber = page ?? 1;
                
            
                return View(competitions.ToPagedList(pageNumber, pageSize));
            
        }
        [Authorize(Roles = "Teacher")]
        public ActionResult CompetitionInvited(string searchString, string sortOrder, string currentFilter, int? page)
        {
            var currentUserId = User.Identity.GetUserId();
            var user = db.Users.Find(currentUserId);
            ViewBag.NameSortPara = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortPara = sortOrder == "Date" ? "date_desc" : "Date";
            var competitions = db.Competitions.Where(c => c.Examiners.Select(e => e.Id).Contains(currentUserId));

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
            int pageSize = 5;
            var pageNumber = page ?? 1;


           
            return View(competitions.ToPagedList(pageNumber, pageSize));

        }
        [Authorize(Roles = "Teacher")]
        public ActionResult DeleteExaminer(int? competitionId, string accountId)
        {
            if (accountId.IsNullOrWhiteSpace() || competitionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var account = db.Users.Find(accountId);
            var currentUserId = User.Identity.GetUserId();
            var competition = db.Competitions.Find(competitionId);
            if (competition != null || competition.Examiners.Contains(account))
            {
                competition.Examiners.Remove(account);
            }
            db.SaveChanges();
            return PartialView("_ListExaminer",competition.Examiners);
            
        }
    }
}