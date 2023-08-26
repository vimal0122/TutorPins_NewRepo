using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TutorLocationDto
    {
        public string Id { get; set; }
        
        public string TutorId { get; set; }
        
        public string LocationId { get; set; }
        public string OtherLocation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual TutorDto Tutor { get; set; }
        public virtual LocationDto Location { get; set; }
    }
}
