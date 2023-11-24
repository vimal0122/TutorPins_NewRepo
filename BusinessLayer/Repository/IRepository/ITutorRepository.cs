using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IRepository
{
    public interface ITutorRepository
    {
        public Task<TutorDto> CreateTutor(TutorDto tutorDto);
        public Task<TutorDto> UpdateTutor(int tutorId, TutorDto tutorDto);
        public Task<TutorDto> GetTutor(int tutorId);
        public Task<IEnumerable<TutorDto>> GetAllTutors();
        public Task<IEnumerable<spGetMatchedTutorDto>> GetTutorsBySubject(int Id);
        public Task<IEnumerable<spGetMatchedTutorDto>> GetTutorsByFilters(FilterTutorRequest request);
        public Task<IEnumerable<TutorDto>> GetTutorsByStatus(string status);
        public Task<bool> SaveMatchedTutor(SaveMatchedTutorRequest request);
        public Task<IEnumerable<spGetTuitionByTutorAndStatusDto>> GetTuitionByTutorAndStatus(int tutorId, int statusId);
    }
}
