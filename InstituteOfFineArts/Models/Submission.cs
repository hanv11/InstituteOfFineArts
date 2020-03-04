using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Provider;

namespace InstituteOfFineArts.Models
{
    public class Submission
    {
        [Key] public int SubmissionId { get; set; }
        public int CompetitionId { get; set; }

        [Required(ErrorMessage = "Update your submission.")]
        public string Picture { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Please enter submission name.")]
        public string SubmissionName { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Updated Post")]
        public DateTime? UpdatedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        // nguoi ta ra submission
        [ForeignKey("Creator")] public string CreatorId { get; set; }
        public virtual Account Creator { get; set; }

        [Required(ErrorMessage = "Please enter decription of submission.")]
        public string Description { get; set; }

        public virtual Competition Competition { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }

        public Submission()
        {
        }

        public SubmissionStatus Status { get; set; }

        public enum SubmissionStatus
        {
            Pending = 0,
            Confirmed = 1,
            Cancel = 2
        }

        public virtual Award Award { get; set; }

        public double MarkAverage
        {
            get {
                var sumOfMark = 0;
                if(Marks == null)
                {
                    return 0;
                }
                if (!Marks.Any())
                {
                    return 0;
                }

                foreach (var item in Marks)
                {
                    sumOfMark += (int)item.Marks;
                }

                return (double)sumOfMark / Marks.Count;
            }

        }
        public Submission(int competid,string creatorid,string pic, string subname, string descrip, DateTime createdat)
        {              
            CompetitionId = competid;
            CreatorId = creatorid;
            CreatedAt = createdat;
            Picture = pic;
            SubmissionName = subname;
            Description = descrip;
        }
    }
}
