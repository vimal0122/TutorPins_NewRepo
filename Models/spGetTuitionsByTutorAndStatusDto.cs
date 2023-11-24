using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class spGetTuitionByTutorAndStatusDto
    {
		public int? StudentId { get; set; }
		public int? TutorId { get; set; }
		public int? StudentSubjectId { get; set; }
		public string StudentName { get; set; }
		public string SubjectName { get; set; }
		public string DurationPerWeek { get; set; }
		public string AdminRemarks { get; set; }
		public DateTime? ActualStartDate { get; set; }
	}
}
