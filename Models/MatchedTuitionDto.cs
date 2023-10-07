using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MatchedTuitionDto
    {
        public int Id { get; set; }        
        public int TutorId { get; set; }        
        public int StudentSubjectId { get; set; }
        public string PaymentStatus { get; set; }
        public string TuitionStatus { get; set; }
        public string ActualStartDate { get; set; }
        public string TutorFeedBack { get; set; }
        public string AdminRemarks { get; set; }
        public string TutitonTime { get; set; }
        public string TutorMatchStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual TutorDto Tutor { get; set; }
        public virtual StudentSubjectDto StudentSubject { get; set; }
    }
}
