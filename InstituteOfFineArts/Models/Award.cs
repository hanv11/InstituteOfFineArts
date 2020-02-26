using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Award
    {
        [Key]
        public int SubmissionId { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
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