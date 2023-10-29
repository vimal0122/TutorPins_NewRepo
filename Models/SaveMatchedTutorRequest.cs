using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SaveMatchedTutorRequest
    {
        public int StudentSubjectId { get; set; }
        public int TutorId { get; set; }
        public int MatchStatusId { get; set; }
        public int UserId { get; set; } = 1;
        public string AdminRemarks { get; set; }
    }
}
