using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Mark
    {
        public string SubmissionId { get; set; }
        public MarkType Marks { get; set; }
        public enum MarkType {
            disqualified = 0,
            normal = 1,
            moderate = 2,
            good = 3,
            better = 4,
            best = 5 }
        public string Description { get; set; }
        public virtual ICollection<Submissions> submissions { get; set; }
    }
}