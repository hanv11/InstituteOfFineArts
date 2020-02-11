using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Students
    {
        string StudentId { get; set; }
        int ClassId { get; set; }
        public virtual Classes classes { get; set; }
    }
}