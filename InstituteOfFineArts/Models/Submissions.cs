using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Submissions
    {
       public string SubmissionId { get; set; }
       public string CompetionId { get; set; }
       public string Picture { get; set; }
       public string StudentId { get; set; }
       public string Description { get; set; }
       public virtual Competitions competitions { get; set; }
       public virtual Mark marks { get; set; }
       public virtual Awards awards { get; set; }
    }
}