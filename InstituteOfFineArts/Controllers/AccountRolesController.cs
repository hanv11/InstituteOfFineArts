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
using Microsoft.AspNet.Identity.EntityFramework;

namespace InstituteOfFineArts.Controllers
{
    public class AccountRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        private RoleManager<AccountRole> _roleManager;

        public AccountRolesController()
        {
            var roleStore = new RoleStore<AccountRole>(db);
            _roleManager = new RoleManager<AccountRole>(roleStore);
        }


        // GET: AccountRoles
        public ActionResult Index()
        {
            return View(db.IdentityRoles.ToList());
        }

        // GET: AccountRoles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountRole accountRole = db.IdentityRoles.Find(id);
            if (accountRole == null)
            {
                return HttpNotFound();
            }
            return View(accountRole);
        }

        // GET: AccountRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] AccountRole accountRole)
        {
            if (ModelState.IsValid)
            {
                db.IdentityRoles.Add(accountRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountRole);
        }

        // GET: AccountRoles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountRole accountRole = db.IdentityRoles.Find(id);
            if (accountRole == null)
            {
                return HttpNotFound();
            }
            return View(accountRole);
        }

        // POST: AccountRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AccountRole accountRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountRole);
        }

        // GET: AccountRoles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountRole accountRole = db.IdentityRoles.Find(id);
            if (accountRole == null)
            {
                return HttpNotFound();
            }
            return View(accountRole);
        }

        // POST: AccountRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AccountRole accountRole = db.IdentityRoles.Find(id);
            db.IdentityRoles.Remove(accountRole);
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
    }
}
