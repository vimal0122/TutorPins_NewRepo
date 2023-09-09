using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class TutorSubject
    {
        [Key]
        public int Id			{get;set;}
        [ForeignKey("Tutor")]
        public int TutorId		{get;set;}
        [ForeignKey("CourseSubject")]
        public int SubjectId		{get;set;}
		public string TutorRate		{get;set;}
        public int? TutorRateValue { get; set; } = 0;
        public string CreatedBy		{get;set;}
		public string CreatedDate	{get;set;}
		public string UpdatedBy		{get;set;}
		public string UpdatedDate { get; set; }
        public virtual Tutor Tutor { get; set; }
        public virtual CourseSubject CourseSubject { get; set; }
    }
}
