using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
       public int AccountId { get; set; }
       public string Description { get; set; }
       public virtual Competition Competitions { get; set; }
       public virtual Mark Marks { get; set; }
       public virtual Award Awards { get; set; }
    }
}