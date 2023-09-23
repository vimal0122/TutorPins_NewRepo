using Models;

namespace TutorPins_Client.Service.IService
{
    public interface ICourseSubjectService
    {
        public Task<IEnumerable<CourseSubjectDto>> GetCourseSubjects();
        public Task<bool> CreateCourseSubject(CourseSubjectDto courseSubjectDto);
        public Task<IEnumerable<CourseSubjectDto>> GetSubjectsByCourse(string courseId);
        public Task<IEnumerable<CourseSubjectDto>> GetSubjectsByCourseCategory(string courseCategoryId);
    }
}
