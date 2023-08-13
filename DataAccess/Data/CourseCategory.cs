﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CourseCategory
    {
        public CourseCategory() {
            Courses = new HashSet<Course>();
        } 
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
