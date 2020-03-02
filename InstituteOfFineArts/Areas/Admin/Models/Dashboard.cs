using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Areas.Admin.Models
{
    public class Dashboard
    {
        public int NumberOfStudent { get; set; }
        public int NumberOfTeacher { get; set; }
        public int NumberOfCompetition { get; set; }
        public int NumberOfCompetitionPending { get; set; }
        public int NumberOfSubmission { get; set; }
    }
}