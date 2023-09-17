using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentLocationDto
    {
        public int Id { get; set; }
        
        public int StudentId { get; set; }
       
        public int LocationId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual StudentDto Student { get; set; }
        public virtual LocationDto Location { get; set; }
    }
}
