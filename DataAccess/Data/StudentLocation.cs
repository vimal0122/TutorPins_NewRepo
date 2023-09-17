using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class StudentLocation
    {
        [Key]
        public int Id				{get;set;}
        [ForeignKey("Student")]
        public int StudentId		{get;set;}
        [ForeignKey("Location")]
        public int LocationId	{get;set;}
		public bool? IsActive		{get;set;}
		public string CreatedBy		{get;set;}
		public DateTime? CreatedDate	{get;set;}
		public string UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
        public virtual Student Student { get; set; }
        public virtual Location Location { get; set; }
    }
}
