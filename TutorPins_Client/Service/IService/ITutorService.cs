﻿using Models;

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
        public Task<bool> SaveMatchedTutor(string studentSubjectId,string tutorId, string matchStatusId);

    }
}
