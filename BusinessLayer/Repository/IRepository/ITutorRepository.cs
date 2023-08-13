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
        public Task<TutorDto> CreateTutor(TutorDto studentDto);
        public Task<TutorDto> UpdateTutor(int tutorId, TutorDto studentDto);
        public Task<TutorDto> GetTutor(int studentId);
        public Task<IEnumerable<TutorDto>> GetAllTutors();
        public Task<IEnumerable<TutorDto>> GetTutorsBySubject(int subjectId);
        public Task<IEnumerable<TutorDto>> GetTutorsByStatus(string status);
    }
}
