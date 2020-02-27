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
        [ForeignKey("Account")]
        public string AccountId { get; set; }
        public virtual Account Account { get; set; }

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
        public Submission(int subid, int competid, string pic, string descrip)
        {
            SubmissionId = subid;
            CompetitionId = competid;
            Picture = pic;
            Description = descrip;
        }
        public virtual Award Awards { get; set; }
    }
}
