﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full name is required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string StudentEmail { get; set; }
        [Required(ErrorMessage = "Student Phoneno is required")]
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
        [Required(ErrorMessage = "Contact mode is required")]
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
        public string LocationDetails { get; set; }
        public string SubjectDetails { get; set; }
        public string MatchStatus { get; set; }
        public virtual ICollection<StudentSubjectDto> StudentSubjects { get; set; }
        public virtual ICollection<StudentLocationDto> StudentLocations { get; set; }
    }
}
