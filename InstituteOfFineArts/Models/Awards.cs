using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Awards
    {
        public string SubmissionId { get; set; }
        public string AwardName { get; set; }
        public virtual ICollection<Submissions> submissions { get; set; }
    }
}