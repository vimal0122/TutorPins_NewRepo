using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class TutorCategory
    {
        [Key]
        public int Id					{get;set;}
        [ForeignKey("CourseCategory")]
        public int? CourseCategoryId	{get;set;}
		public string TutorCategoryName	{get;set;}		
		public int? CreatedBy			{get;set;}
		public DateTime? CreatedDate	{get;set;}
		public int? UpdatedBy			{get;set;}
		public DateTime? UpdatedDate { get; set; }
        public virtual CourseCategory CourseCategory { get; set; }
    }
}
