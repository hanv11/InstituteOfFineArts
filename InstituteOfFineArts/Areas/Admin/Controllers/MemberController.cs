using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PagedList;

namespace InstituteOfFineArts.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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

        // GET: Admin/Member/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = "Student";

                switch (model.UserType)
                {
                    case Account.UserTypes.Teacher:
                        role = "Teacher";
                        break;
                    case Account.UserTypes.Admin:
                        role = "Admin";
                        break;
                    case Account.UserTypes.Manager:
                        role = "Manager";
                        break;
                    default:
                        role = "Student";
                        break;
                }

                var user = new Account
                {
                    UserName = model.Email, Email = model.Email, CreatedAt = DateTime.Now, UpdateAt = DateTime.Now,
                    FirstName = model.FirstName, LastName = model.LastName, Birthday = model.Birthday,
                    Gender = (Account.GenderType) model.Gender,
                    UserType = (Account.UserTypes)model.UserType
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, role);
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Member");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        // GET: Admin/Member/Edit/5
        public ActionResult Edit(string id)
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

            
            var model = new UpdateViewModel()
            {
                Birthday = account.Birthday,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                UserType = account.UserType,
                Gender = account.Gender,
                UserCode = account.UserCode,
                Status = account.Status,
                PhoneNumber = account.PhoneNumber
            };
            return View(model);
        }

        // POST: Admin/Member/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
            
                var account = db.Users.Find(model.Id);
                if (account == null)
                {
                    return HttpNotFound();
                }

                var usertype = (int) account.UserType;
                var role = "Student";
                switch (model.UserType)
                {
                    case Account.UserTypes.Teacher:
                        role = "Teacher";
                        break;
                    case Account.UserTypes.Admin:
                        role = "Admin";
                        break;
                    case Account.UserTypes.Manager:
                        role = "Manager";
                        break;
                    default:
                        role = "Student";
                        break;
                }
                var roles = await UserManager.GetRolesAsync(model.Id);
                await UserManager.RemoveFromRolesAsync(model.Id, roles.ToArray());
               await UserManager.AddToRoleAsync(model.Id, role);
                db.Entry(account).State = EntityState.Modified;
                account.UserName = model.Email;
                account.Birthday = model.Birthday;
                account.FirstName = model.FirstName;
                account.LastName = model.LastName;
                account.Email = model.Email;
                account.UserType = model.UserType;
                account.Gender = (Account.GenderType)model.Gender;
                account.UserCode = model.UserCode;
                account.Status = model.Status;
                account.UpdateAt = DateTime.Now;
                account.PhoneNumber = model.PhoneNumber;
                db.SaveChanges();
                if (usertype == (int) Account.UserTypes.Teacher)
                {
                    return RedirectToAction("ListTeacher");
                }

                if (usertype == (int) Account.UserTypes.Student)
                {
                    return RedirectToAction("ListStudent");
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Admin/Member/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Admin/Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Account account = db.Users.Find(id);
           account.DeletedAt = DateTime.Now;
           account.Status = Account.AccountStatus.Deleted;
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
            int pageSize = 5;
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
