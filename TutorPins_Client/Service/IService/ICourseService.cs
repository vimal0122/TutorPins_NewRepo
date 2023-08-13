using Models;
namespace TutorPins_Client.Service.IService
{
    public interface ICourseService
    {
        public Task<IEnumerable<CourseDto>> GetCourses();
        public Task<bool> CreateCourse(CourseDto courseDto);
        public Task<IEnumerable<CourseDto>> GetCoursesByCategory(string categoryId);
    }
}
