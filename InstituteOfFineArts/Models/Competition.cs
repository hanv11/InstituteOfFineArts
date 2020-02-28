using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Competition
    {
        [Key]
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        [ForeignKey("Creator")]
        // nguoi tao ra cuoc thi
        public string CreatorId { get; set; }
        public virtual Account Creator { get; set; }
        // cac giam khao duoc chon
        public virtual ICollection<Account> Examiners { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string AwardDetail { get; set; }
        public bool IsSlide { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public CompetitionStatus Status { get; set; }
        public enum CompetitionStatus
        {
            Pending = 0,
            Confirmed = 1,
            Finished = 2
        }
        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual ICollection<Account> Participants { get; set; }
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