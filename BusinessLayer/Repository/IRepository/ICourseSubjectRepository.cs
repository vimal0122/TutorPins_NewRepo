using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IRepository
{
    public interface ICourseSubjectRepository
    {
        public Task<CourseSubjectDto> CreateSubject(CourseSubjectDto courseSubjectDto);
        public Task<CourseSubjectDto> UpdateSubject(int courseSubjectId, CourseSubjectDto courseSubjectDto);
        public Task<CourseSubjectDto> GetSubject(int courseSubjectId);
        public Task<IEnumerable<CourseSubjectDto>> GetAllSubjects();
        public Task<IEnumerable<CourseSubjectDto>> GetSubjectsByCourse(int courseId);
    }
}
