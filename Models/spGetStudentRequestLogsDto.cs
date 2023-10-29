using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class spGetStudentRequestLogDto
    {
        public Int64 Id { get; set; }
        public int StudentSubjectId { get; set; }
        public int? TutorId { get; set; }
        public DateTime? ChangedDate { get; set; }
        public string ChangedStatus { get; set; }
        public int? ChangedStatusId { get; set; }
        public string FullRecord { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string TutorName { get; set; }
        public string AdminRemarks { get; set; }
    }
}
