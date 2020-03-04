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
        [Required(ErrorMessage = "Please enter competition name.")]
        public string CompetitionName { get; set; }
        [ForeignKey("Creator")]
        // nguoi tao ra cuoc thi
        public string CreatorId { get; set; }
        public virtual Account Creator { get; set; }
       
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CancelAt { get; set; }
        [Required(ErrorMessage = "Please enter banner of competition.")]
        public string Image { get; set; }
        public string Slide { get; set; }
        [Required(ErrorMessage = "Please enter some decription of competition.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter slogan of competition.")]
        public string ShortDescription { get; set; }
        public string AwardDetail { get; set; }
        public bool IsSlide { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public CompetitionStatus Status { get; set; }
        public enum CompetitionStatus
        {
            Cancel = -1,
            Pending = 0,
            Confirmed = 1,
            Completed = 2,
            Finished = 3,
            
        }
        public virtual ICollection<Submission> Submissions { get; set; }
        [InverseProperty("Competitions")]
        public virtual ICollection<Account> Participants { get; set; }
        // cac giam khao duoc chon
        [InverseProperty("ACompetitions")]
        public virtual ICollection<Account> Examiners { get; set; }
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