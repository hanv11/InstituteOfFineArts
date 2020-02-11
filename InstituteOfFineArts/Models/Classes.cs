using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Classes
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<Classes> classes { get; set; }

    }
}