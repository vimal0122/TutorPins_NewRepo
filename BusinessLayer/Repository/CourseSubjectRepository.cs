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
    public class CourseSubjectRepository : ICourseSubjectRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CourseSubjectRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CourseSubjectDto> CreateSubject(CourseSubjectDto courseSubjectDto)
        {
            try
            {
                CourseSubject courseSubject = _mapper.Map<CourseSubjectDto, CourseSubject>(courseSubjectDto);
                courseSubject.CreatedDate = DateTime.Now;
                courseSubject.CreatedBy = "1";
                var addedCourseSubject = await _db.CourseSubjects.AddAsync(courseSubject);
                await _db.SaveChangesAsync();
                return _mapper.Map<CourseSubject, CourseSubjectDto>(addedCourseSubject.Entity);
            }
            catch(Exception ex) 
            {
                var x = 0;
            }    
            return null;
        }

        public async Task<IEnumerable<CourseSubjectDto>> GetAllSubjects()
        {
            try
            {
                await Task.Delay(1);

                IEnumerable<CourseSubjectDto> courseSubjectDtos = _mapper.Map<IEnumerable<CourseSubject>, IEnumerable<CourseSubjectDto>>(_db.CourseSubjects.Include(x=>x.Course).ThenInclude(t=>t.CourseCategory));
                //if (!string.IsNullOrEmpty(Ids))
                //{
                //    string[] subjects = Ids.Split(',', StringSplitOptions.RemoveEmptyEntries);
                //    courseSubjectDtos = courseSubjectDtos.Where(t => subjects.Contains(t.Id.ToString()));
                //}
                return courseSubjectDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CourseSubjectDto> GetSubject(int courseSubjectId)
        {
            try
            {
                CourseSubjectDto courseSubjectDto = _mapper.Map<CourseSubject, CourseSubjectDto>(await _db.CourseSubjects.FirstOrDefaultAsync(x => x.Id == courseSubjectId));
                return courseSubjectDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<CourseSubjectDto>> GetSubjectsByCourse(string courseId)
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<CourseSubjectDto> subjectDtos;
                subjectDtos = _mapper.Map<IEnumerable<CourseSubject>, IEnumerable<CourseSubjectDto>>(_db.CourseSubjects.Include(x => x.Course));
                if (!string.IsNullOrEmpty(courseId))
                {
                    string[] courses = courseId.Split(',', StringSplitOptions.RemoveEmptyEntries);
                     subjectDtos = subjectDtos.Where(t => courses.Contains(t.CourseId.ToString()));
                }
                 
                return subjectDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CourseSubjectDto> UpdateSubject(int courseSubjectId, CourseSubjectDto courseSubjectDto)
        {
            try
            {
                if (courseSubjectId == courseSubjectDto.Id)
                {
                    CourseSubject courseSubjectDetails = await _db.CourseSubjects.FirstOrDefaultAsync(x => x.Id == courseSubjectId);
                    CourseSubject courseSubject = _mapper.Map<CourseSubjectDto, CourseSubject>(courseSubjectDto, courseSubjectDetails);
                    courseSubject.UpdatedDate = DateTime.Now;
                    courseSubject.UpdatedBy = "1";
                    var updatedCourse = _db.CourseSubjects.Update(courseSubject);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<CourseSubject, CourseSubjectDto>(updatedCourse.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
