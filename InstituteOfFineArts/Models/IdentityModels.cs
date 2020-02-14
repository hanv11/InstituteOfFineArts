﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InstituteOfFineArts.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
   

    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<InstituteOfFineArts.Models.Competition> Competitions { get; set; }

        public System.Data.Entity.DbSet<InstituteOfFineArts.Models.Awards> Awards { get; set; }

        public System.Data.Entity.DbSet<InstituteOfFineArts.Models.Submission> Submissions { get; set; }

    }
}