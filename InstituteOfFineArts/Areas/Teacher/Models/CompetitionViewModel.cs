using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstituteOfFineArts.Models;

namespace InstituteOfFineArts.Areas.Teacher.Models
{
    public class CompetitionViewModel
    {
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}