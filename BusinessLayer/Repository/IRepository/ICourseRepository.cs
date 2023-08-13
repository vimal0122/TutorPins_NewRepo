using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IRepository
{
    public interface ICourseRepository
    {
        public Task<CourseDto> CreateCourse(CourseDto courseDto);
        public Task<CourseDto> UpdateCourse(int courseId, CourseDto courseDto);
        public Task<CourseDto> GetCourse(int courseId);
        public Task<IEnumerable<CourseDto>> GetAllCourses();
        public Task<IEnumerable<CourseDto>> GetCoursesByCategory(int categoryId);
        public Task<CourseDto> IsCourseUnique(string courseName);
    }
}
