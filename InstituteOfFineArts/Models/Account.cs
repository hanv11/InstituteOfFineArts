using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
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
        [Required(ErrorMessage = "Please enter first name of member.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name of member.")]
        public string LastName { get; set; }
        public string UserCode { get; set; }
        [Required(ErrorMessage = "Please enter email of member.")]
        [DataType(DataType.EmailAddress)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public override string  Email { get; set; }
        [Required(ErrorMessage = "Please enter birthday of member.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Birthday { get; set; }
        [Required(ErrorMessage = "Please choose gender of member.")]
        public GenderType Gender { get; set; }
        [Required(ErrorMessage = "Update avatar.")]
        public string Avatar { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Submission> Submissions { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<Competition> ACompetitions { get; set; }
        [Required(ErrorMessage = "Please choose user type.")]
        public UserTypes UserType { get; set; }
        public enum GenderType
        {
            Male = 0,
            FeMale = 1,
        }
        public enum UserTypes
        {
            Student = 0,
            Teacher = 1,
            Manager = 2,
            Admin = 3
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