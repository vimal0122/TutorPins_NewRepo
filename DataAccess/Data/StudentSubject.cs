using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class StudentSubject
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("CourseSubject")]
        public int SubjectId { get; set; }
        public string DurationPerWeek { get; set; }
        public string PreferedTimeSlots { get; set; }
        public string SubjectFullName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? TutorMatched { get;set; }
        public string TutorMatchStatus { get; set; }
        public virtual Student Student { get; set; }        
        public virtual CourseSubject CourseSubject { get; set; }
        public virtual ICollection<MatchedTuition> MatchedTuitions { get; set; }
    }
}
