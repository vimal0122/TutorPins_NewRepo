using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FilterTutorRequest
    {
        public int Id { get; set; }
        public int? HourlyRateMinValue { get; set; }    
        public int? HourlyRateMaxValue { get; set; }
        public string FilterTutorCategoryId { get; set; }
        public string FilterTutorGenderId { get; set; }
        public string FilterRaceId { get; set; }
        public string FilterRatingValue { get; set; }
        public int? FilterLocationId { get; set; }
        public string FilterModeId { get; set; }
        
    }
    public class FilterTutionRequest
    {
        public int TutorId { get; set; }
        public int StatusId { get; set; }
    }
    public class StudentHistoryRequest
    {
        public int StudentId { get; set; }
        public int StudentSubjectId { get; set; }
    }
}
