using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CourseDto
    {        
        public int Id { get; set; }
        [Required(ErrorMessage ="Course name is mandatory.")]
        public string CourseName { get; set; }
        public int CourseCategoryId { get; set; }
        public bool IsActive { get; set; }
        public CourseCategoryDto CourseCategory { get; set; }

    }
}
