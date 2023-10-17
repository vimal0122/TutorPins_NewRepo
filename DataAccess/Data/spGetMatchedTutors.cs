using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class spGetMatchedTutor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TutorName { get; set; }
        public string TutorEmail { get; set; }
        public string TutorPhoneNo { get; set; }
        public string TutorGender { get; set; }
        public DateTime? TutorDOB { get; set; }
        public string TutorRace { get; set; }
        public string TutorCategory { get; set; }
        public int TutorRate { get; set; }
        public string TutorImage { get; set; }

        public string TutorMode { get; set; }
        public string TutorAcademicResults { get; set; }
        public string TutorSelf { get; set; }
        public string TutorRating { get; set; }
        public string AdminRemarks { get; set; }
        public string TutorStatus { get; set; }
        public string OtherLocation { get; set; }
        public string AlreadyMatched { get; set; }  
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int MatchStatusId { get; set; }
    }
    public class spGetMatchedTutorsByFilter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TutorName { get; set; }
        public string TutorEmail { get; set; }
        public string TutorPhoneNo { get; set; }
        public string TutorGender { get; set; }
        public DateTime? TutorDOB { get; set; }
        public string TutorRace { get; set; }
        public string TutorCategory { get; set; }
        public int TutorRate { get; set; }
        public string TutorImage { get; set; }

        public string TutorMode { get; set; }
        public string TutorAcademicResults { get; set; }
        public string TutorSelf { get; set; }
        public string TutorRating { get; set; }
        public string AdminRemarks { get; set; }
        public string TutorStatus { get; set; }
        public string OtherLocation { get; set; }
        public string AlreadyMatched { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int MatchStatusId { get; set; }
    }
}
