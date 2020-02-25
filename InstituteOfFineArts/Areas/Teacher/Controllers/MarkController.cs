using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Models;
using Microsoft.AspNet.Identity;

namespace InstituteOfFineArts.Areas.Teacher.Controllers
{
    public class MarkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teacher/Mark
        public ActionResult Index()
        {
            var marks = db.Marks.Include(m => m.Examiner).Include(m => m.Submission);
            return View(marks.ToList());
            
           
        }

        // GET: Teacher/Mark/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // GET: Teacher/Mark/Create
        public ActionResult Create(int? id)
        {
            Submission submission = db.Submissions.Find(id);
            ViewBag.SubmissionId = id;
            ViewBag.Picture = submission.Picture;
            return View();
        }

        // POST: Teacher/Mark/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarkId,SubmissionId,AccountId,Marks,Description")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                var teacherId = User.Identity.GetUserId();
                var account = db.Users.FirstOrDefault(u => u.Id == teacherId);
                mark.AccountId = teacherId;
                mark.Examiner = account;
                db.Marks.Add(mark);
                db.SaveChanges();
                return RedirectToAction("_ListMark");
            }
            return View(mark);
        }

        // GET: Teacher/Mark/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Users, "Id", "FirstName", mark.AccountId);
            ViewBag.SubmissionId = new SelectList(db.Submissions, "SubmissionId", "Picture", mark.SubmissionId);
            return View(mark);
        }

        // POST: Teacher/Mark/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarkId,SubmissionId,AccountId,Marks,Description")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Users, "Id", "FirstName", mark.AccountId);
            ViewBag.SubmissionId = new SelectList(db.Submissions, "SubmissionId", "Picture", mark.SubmissionId);
            return View(mark);
        }

        // GET: Teacher/Mark/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // POST: Teacher/Mark/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mark mark = db.Marks.Find(id);
            db.Marks.Remove(mark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ListMark(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Users.Find(Id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        public ActionResult _ListMark(string Id)
        {
            var teacher = db.Marks.Where(s => s.AccountId == Id);
            return PartialView("_ListMark",teacher.ToList());
        }
    }
}
