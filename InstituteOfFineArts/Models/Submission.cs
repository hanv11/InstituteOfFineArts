using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Submission
    {
        [Key]
        public int SubmissionId { get; set; }
        public int CompetitionId { get; set; }
        public string Picture { get; set; }
        [DisplayName("Name")]
        public string SubmissionName { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Updated Post")]
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        // nguoi ta ra submission
        [ForeignKey("Creator")]
        public string CreatorId { get; set; }
        public virtual Account Creator { get; set; }
        public string Description { get; set; }
        public virtual Competition Competition { get; set; }
        public virtual ICollection<Mark > Marks { get; set; }
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

        public  double MarkAverage()
        {
            var sumOfMark = 0;
            if (!Marks.Any())
            {
                return 0;
            }

            foreach (var item in Marks)
            {
                sumOfMark += (int) item.Marks * 2;
            }

            return (double)sumOfMark / Marks.Count;

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
