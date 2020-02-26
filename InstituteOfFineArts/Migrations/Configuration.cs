namespace InstituteOfFineArts.Migrations
{
    using InstituteOfFineArts.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InstituteOfFineArts.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InstituteOfFineArts.Models.ApplicationDbContext context)
        {
            
        }
    }
}
