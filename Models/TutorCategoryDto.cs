using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class TutorCategoryDto
    {
        public int Id { get; set; }
        
        public int? CourseCategoryId { get; set; }
        public string TutorCategoryName { get; set; }        
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual CourseCategoryDto CourseCategory { get; set; }
    }
}
