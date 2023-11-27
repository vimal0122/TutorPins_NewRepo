using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class spGetAllFeedbackDto
	{	
	
		public int Id { get; set; }
		public int TutorId { get; set; }
		public int StudentSubjectId { get; set; }
		public string Comments { get; set; }
		public int? CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string HasRead { get; set; }		
		public string StudentName { get; set; }
		public string TutorName { get; set; }
        public string SubjectFullName { get; set; }
        

    }
}
