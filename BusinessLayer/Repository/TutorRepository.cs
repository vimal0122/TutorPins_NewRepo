using AutoMapper;
using BusinessLayer.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class TutorRepository : ITutorRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public TutorRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<TutorDto> CreateTutor(TutorDto tutorDto)
        {
            try
            {
                Tutor tutor = _mapper.Map<TutorDto, Tutor>(tutorDto);
                
                tutor.CreatedDate = DateTime.Now;
                tutor.CreatedBy = "1";
                var addedTutor = await _db.Tutors.AddAsync(tutor);
                await _db.SaveChangesAsync();

                return _mapper.Map<Tutor, TutorDto>(addedTutor.Entity);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<IEnumerable<TutorDto>> GetAllTutors()
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<TutorDto> tutorDtos = _mapper.Map<IEnumerable<Tutor>, IEnumerable<TutorDto>>(_db.Tutors.Include(t=>t.TutorLocations).ThenInclude(x=>x.Location).Include(t=>t.TutorQualifications).ThenInclude(t=>t.Qualification).Include(t=>t.TutorSubjects).ThenInclude(x=>x.CourseSubject));
                
                return tutorDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<TutorDto> GetTutor(int tutorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TutorDto>> GetTutorsByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TutorDto>> GetTutorsBySubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<TutorDto> UpdateTutor(int tutorId, TutorDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
