﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InstituteOfFineArts.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace InstituteOfFineArts.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
            int pageSize = 5;
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

       
        [Authorize(Roles = "Admin")]
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
            return View(competition);
        }

        // POST: Competitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "CompetitionId,CompetitionName,StartDate,EndDate,Image,AwardDetails,Description, CreatorId")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyCompetition");
            }
            return View(competition);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
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
            competition.Status = Competition.CompetitionStatus.Cancel;
            competition.UpdatedAt = DateTime.Now;
           
            return View(competition);
        }
        [Authorize(Roles = "Admin")]
        // POST: Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competition competition = db.Competitions.Find(id);
            db.Competitions.Remove(competition ?? throw new InvalidOperationException());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ConfirmCompetition(int? competitionId)
        {
            if (competitionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var competition = db.Competitions.Find(competitionId);
            if (competition == null)
            {
                return HttpNotFound();
            }

            competition.Status = Competition.CompetitionStatus.Confirmed;
            db.SaveChanges();
            return new JsonResult()
            {
                Data = competition.Status,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}