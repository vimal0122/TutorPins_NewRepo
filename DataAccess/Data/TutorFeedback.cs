using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
	public class TutorFeedback
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Tutor")]
		public int TutorId { get; set; }
		[ForeignKey("StudentSubject")]
		public int StudentSubjectId { get; set; }		
		public string Comments { get; set; }		
		public string CreatedBy { get; set; }
		public bool? HasRead { get; set; }
		public DateTime? CreatedDate { get; set; }
		public virtual Tutor Tutor { get; set; }
		public virtual StudentSubject StudentSubject { get; set; }
	}
}
