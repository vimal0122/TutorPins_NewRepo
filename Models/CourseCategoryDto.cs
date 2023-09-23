using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CourseCategoryDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "CategoryName is mandatory.")]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ICollection<CourseDto> Courses { get; set; }
        public virtual ICollection<TutorCategoryDto> TutorCategories { get; set; }
    }
}
