using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public  class TutorQualification
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Tutor")]
        public int TutorId { get; set; }
        [ForeignKey("Qualification")]
        public int QualificationId { get; set; }
        public string SubjectsCovered { get; set; }
        public string YearOfCompletion { get; set; }
        public string GradeObtained { get; set; }
        public string DocumentPath { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual Tutor Tutor { get; set; }
        public virtual Qualification Qualification { get; set; }
    }
}
