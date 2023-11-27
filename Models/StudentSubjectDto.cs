using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentSubjectDto
    {
        public int Id { get; set; }
        
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int SubjectId { get; set; }
        public string DurationPerWeek { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CategoryName { get; set; }
        public string SubjectFullName { get; set; }
        public string CourseName { get; set; }
        public string SubjectName { get; set; }
        public bool? TutorMatched { get; set; }
        public string TutorMatchStatus { get; set; }
        public string PreferedTimeSlots { get; set; }
		public string AdminRemarks { get; set; }		
		public virtual StudentDto Student { get; set; }
        public virtual CourseSubjectDto CourseSubject { get; set; }
        public virtual ICollection<MatchedTuitionDto> MatchedTuitions { get; set; }
		public virtual ICollection<TutorFeedbackDto> TutorFeedbacks { get; set; }
	}
}
