using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        [ForeignKey("CourseCategory")]
        public int CourseCategoryId { get; set; }
        public bool IsActive { get;set;}
        public string? CreatedBy { get; set; }
        public  DateTime CreatedDate { get; set; } 
        public string? UpdatedBy { get; set;}
        public DateTime? UpdatedDate { get; set;}
        public virtual CourseCategory CourseCategory { get; set; }
        public virtual ICollection<CourseSubject> CourseSubjects { get; set; }

    }
}
