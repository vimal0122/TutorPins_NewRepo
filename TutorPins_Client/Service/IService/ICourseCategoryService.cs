using Models;

namespace TutorPins_Client.Service.IService
{
    public interface ICourseCategoryService
    {
        public Task<IEnumerable<CourseCategoryDto>?> GetCourseCategories();
        public Task<bool> CreateCourseCategory(CourseCategoryDto courseCategoryDto);
        public Task<CourseCategoryDto> UpdateCourseCategory(int courseCategoryId, CourseCategoryDto courseCategoryDto);
        public Task<CourseCategoryDto> GetCourseCategory(int courseCategoryId);
    }
}
