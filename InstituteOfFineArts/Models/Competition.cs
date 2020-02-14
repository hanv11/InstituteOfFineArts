using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Competition
    {
        [Key]
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Award> Awards { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
        public Competition()
        {

        }
        public Competition(int competid, string competname, DateTime sdate, DateTime edate, string img, string awarddetail , string decription)
        {
            CompetitionId = competid;
            CompetitionName = competname;
            StartDate = sdate;
            EndDate = edate;
            Image = img;
            Description = decription;
        }
    }
}