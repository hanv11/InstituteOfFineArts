using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstituteOfFineArts.Models;

namespace InstituteOfFineArts.Areas.Teacher.Models
{
    public class AwardViewModel
    {
        public int? SubmissionId { get; set; }
            public string Image { get; set; }
            public int? Mark { get; set; }
            public string StudentName { get; set; }
            public int MarkId { get; set; }
            public virtual ICollection<Submission> Submissions { get; set; }
            public Award.AwardType Award { get; set; }
    }
}