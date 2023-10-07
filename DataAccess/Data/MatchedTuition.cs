using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class MatchedTuition
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Tutor")]
        public int TutorId { get; set; }
        [ForeignKey("StudentSubject")]
        public int StudentSubjectId { get;set;}
		public string PaymentStatus { get;set;}
		public string TuitionStatus { get;set;}
		public string ActualStartDate { get;set;}
		public string TutorFeedBack { get;set;}
		public string AdminRemarks { get;set;}
		public string TutitonTime { get;set;}
		public string CreatedBy { get;set;}
		public DateTime? CreatedDate { get;set;}
		public string UpdatedBy { get;set;}
		public DateTime? UpdatedDate { get;set;}
        public string TutorMatchStatus { get; set; }
        
        public virtual Tutor Tutor { get; set; }
        public virtual StudentSubject StudentSubject { get; set; }
    }
}
