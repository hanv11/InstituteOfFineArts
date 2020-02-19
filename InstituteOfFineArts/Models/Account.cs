using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InstituteOfFineArts.Models
{
    public class Account : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string  Email { get; set; }
        public DateTime? Birthday { get; set; }
        public GenderType Gender { get; set; }
        public string Avatar { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Submission> Submissions { get; set; }
        public enum GenderType
        {
            Male = 0,
            FeMale = 1,
        }
        public AccountStatus Status { get; set; }
        public enum AccountStatus
        {
            Active = 0,
            DeActive = 1,
            Deleted = 2,
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Account> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }

}