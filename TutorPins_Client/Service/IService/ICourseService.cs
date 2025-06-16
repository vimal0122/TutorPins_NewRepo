using Models;
namespace TutorPins_Client.Service.IService
{
    public interface ICourseService
    {
        public Task<IEnumerable<CourseDto>> GetCourses();
        public Task<CourseDto> CreateCourse(CourseDto courseDto);
        public Task<IEnumerable<CourseDto>> GetCoursesByCategory(string categoryId);
        public Task<CourseDto> GetCourse(int courseId);
    }
}
