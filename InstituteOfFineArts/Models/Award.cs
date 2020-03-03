using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Award
    {
        [ForeignKey("Submission")]
        public int AwardId { get; set; }
        public int SubmissionId { get; set; }
        public virtual Submission Submission{ get; set; }
        [Required(ErrorMessage = "Please choose award for submission.")]
        public AwardType AwardName { get; set; }
        public enum AwardType 
        {
            firstprize = 1,
            thesecondprize = 2,
            thethirdprize = 3,
            none = 0
        }
    }
}