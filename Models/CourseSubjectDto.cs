using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CourseSubjectDto
    {
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }
        public int CourseId { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public CourseDto Course { get; set; }
        public virtual ICollection<TutorSubjectDto> TutorSubjects { get; set; }
    }
}
