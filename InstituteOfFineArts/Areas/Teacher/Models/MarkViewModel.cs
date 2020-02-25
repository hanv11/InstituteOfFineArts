using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstituteOfFineArts.Models;

namespace InstituteOfFineArts.Areas.Teacher.Models
{
    public class MarkViewModel
    {
        public int? MarkId { get; set; }
        public string Image { get; set; }
        public int SubmisstionId { get; set; }
        public string Description { get; set; }
        public Mark.MarkType? Mark { get; set; }
        public string StudentName { get; set; }

    }
}