using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Mark
    {
        [Key]
        public int SubmissionId { get; set; }
        public MarkType Marks { get; set; }
        public enum MarkType {
            disqualified = 0,
            normal = 1,
            moderate = 2,
            good = 3,
            better = 4,
            best = 5 }
        public string Description { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}