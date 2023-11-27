using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class TutorFeedbackDto
	{		
		public int Id { get; set; }		
		public int TutorId { get; set; }		
		public int StudentSubjectId { get; set; }
		public string Comments { get; set; }
		public bool? HasRead { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
		public virtual TutorDto Tutor { get; set; }
		public virtual StudentSubjectDto StudentSubject { get; set; }
	}
}
