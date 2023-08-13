using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CourseSubject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<TutorSubject> TutorSubjects { get; set; }
    }
}
