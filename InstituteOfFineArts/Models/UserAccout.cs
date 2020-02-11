using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class UserAccout
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public GenderType Gender { get; set; }
        public enum GenderType {
            male = 0,
            female = 1
        }
        public string Images { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime Role { get; set; }
        public enum RoleType
        {
            admin = 1,
            teacher = 2,
            manager = 3,
            student = 4
        }
    }
}