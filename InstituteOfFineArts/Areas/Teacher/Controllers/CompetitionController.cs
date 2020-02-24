﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InstituteOfFineArts.Areas.Teacher.Controllers
{
    public class CompetitionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<Account> _userManager = new UserManager<Account>(new UserStore<Account>());
        // GET: Teacher/Competition
        public ActionResult Index()
        {
            return View(db.Competitions.ToList());
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetitionId,CompetitionName,StartDate,EndDate,Image,AwardDetails,Description")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                competition.Status = Competition.CompetitionStatus.Pending;
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
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // POST: Competitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Teacher")]
        public ActionResult Edit([Bind(Include = "CompetitionId,CompetitionName,StartDate,EndDate,Image,AwardDetails,Description")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competition);
        }
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
            var teacher = (from user in db.Users
                from role in user.Roles
                join userRole in db.Roles on role.RoleId equals userRole.Id
                where userRole.Name == "Teacher"
                select new
                {
                    id = user.Id,
                    name = user.FirstName + user.LastName
                });

            return new JsonResult()
            {
                Data = teacher,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult AddExaminer(string accountId)
        {
            if (accountId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var account = db.Users.FirstOrDefault(x => x.Id.Equals(accountId));
            var currentUserId = User.Identity.GetUserId();
            var competition = db.Competitions.FirstOrDefault(c => c.CreatorId.Equals(currentUserId));

            if (competition.Examiners.Contains(account))
            {
                return null;
            }
            competition.Examiners.Add(account);
            return new JsonResult()
            {
                Data = account,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}