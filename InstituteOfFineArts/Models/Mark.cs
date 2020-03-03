using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstituteOfFineArts.Models
{
    public class Mark
    {
        [Key]
        public int MarkId { get; set; }
        [ForeignKey("Submission")]
        public int SubmissionId { get; set; }
        public virtual Submission Submission { get; set; }
        
        // nguoi duoc cho phep cham thi
        [ForeignKey("Examiner")]
        public string AccountId { get; set; }
        public virtual Account Examiner { get; set; }
        [Required(ErrorMessage = "Please choose mark for submission.")]
        public MarkType Marks { get; set; }
        [Required(ErrorMessage = "Please enter comment for submission.")]
        public string Description { get; set; }
        public enum MarkType
        {
            Disqualified = 0,
            Normal = 1,
            Moderate = 2,
            Good = 3,
            Better = 4,
            Best = 5
        }

    }
}