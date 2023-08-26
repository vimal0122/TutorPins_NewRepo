using Models;

namespace TutorPins_Client.Service.IService
{
    public interface ICourseSubjectService
    {
        public Task<IEnumerable<CourseSubjectDto>> GetCourseSubjects(string ids = null);
        public Task<bool> CreateCourseSubject(CourseSubjectDto courseSubjectDto);
        public Task<IEnumerable<CourseSubjectDto>> GetSubjectsByCourse(string courseId);
    }
}
