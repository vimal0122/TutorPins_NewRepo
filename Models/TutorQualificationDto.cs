using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TutorQualificationDto
    {
        public int Id { get; set; }
        
        public int TutorId { get; set; }
        
        public int QualificationId { get; set; }
        public string SubjectsCovered { get; set; }
        public string YearOfCompletion { get; set; }
        public string GradeObtained { get; set; }
        public string DocumentPath { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual TutorDto Tutor { get; set; }
        public virtual QualificationDto Qualification { get; set; }
    }
}
