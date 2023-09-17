using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhoneNo { get; set; }
        public string ParentName { get; set; }
        public string ParentRelation { get; set; }
        public string ParentEmail { get; set; }
        public string ParentPhoneNo { get; set; }
        public string AdminRemarks { get; set; }
        public string StudentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string RequestFrom { get; set; }
        public string PostalCode { get; set; }
        public string PreferedContactMode { get; set; }
        public string PreferedTutorCategory { get; set; }
        public string PreferedTutoringMode { get; set; }
        public string CurrentInstitution { get; set; }
        public DateTime? EarliestStartDate { get; set; }
        public string PreferedTimeSlots { get; set; }
        public string TutorCommitment { get; set; }
        public string PreferedTutorRace { get; set; }
        public string PreferedTutorGender { get; set; }
        public string HoursPerWeek { get; set; }
        public string HoursPerSubject { get; set; }
        public string AdditionalDetails { get; set; }
        public int? ApproxBudget { get; set; }
        public string OtherLocation { get; set; }
        public virtual ICollection<StudentSubjectDto> StudentSubjects { get; set; }
        public virtual ICollection<StudentLocationDto> StudentLocations { get; set; }
    }
}
