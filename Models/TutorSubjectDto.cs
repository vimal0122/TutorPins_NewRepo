using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TutorSubjectDto
    {
        public int Id { get; set; }
        
        public int TutorId { get; set; }
        
        public int SubjectId { get; set; }
        public string TutorRate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string CategoryName { get; set; }
        public string CourseName { get; set; }
        public string SubjectName { get; set; }
        public virtual TutorDto Tutor { get; set; }
        public virtual CourseSubjectDto CourseSubject { get; set; }
    }
}
