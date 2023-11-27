using Models;

namespace TutorPins_Client.Service.IService
{
    public interface ITutorService
    {
        public Task<bool> CreateTutor(TutorDto tutorDto);
        public Task<TutorDto> UpdateTutor(int tutorId, TutorDto tutorDto);
        public Task<TutorDto> GetTutor(string tutorId);
        public Task<IEnumerable<TutorDto>> GetAllTutors();
        public Task<IEnumerable<spGetMatchedTutorDto>> GetTutorsBySubject(string Id);
        public Task<IEnumerable<spGetMatchedTutorDto>> GetTutorsByFilters(FilterTutorRequest request);
        public Task<IEnumerable<TutorDto>> GetTutorsByStatus(string status);
        public Task<bool> SaveMatchedTutor(string studentSubjectId,string tutorId, string matchStatusId, string adminRemarks);
        public Task<IEnumerable<spGetTuitionByTutorAndStatusDto>> GetTuitionByTutorAndStatus(FilterTutionRequest request);
		public Task<bool> SaveFeedback(TutorFeedbackDto dto);
        public Task<IEnumerable<spGetAllFeedbackDto>> GetAllFeedbacks(string tutorId);
        public Task<bool> UpdateFeedback(int feedBackId, TutorFeedbackDto dto);

    }
}
