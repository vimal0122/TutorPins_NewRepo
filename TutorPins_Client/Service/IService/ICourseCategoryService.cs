using Models;

namespace TutorPins_Client.Service.IService
{
    public interface ICourseCategoryService
    {
        public Task<IEnumerable<CourseCategoryDto>?> GetCourseCategories();
        public Task<bool> CreateCourseCategory(CourseCategoryDto courseCategoryDto);
        public Task<CourseCategoryDto> UpdateCourseCategory(int courseCategoryId, CourseCategoryDto courseCategoryDto);
        public Task<CourseCategoryDto> GetCourseCategory(int courseCategoryId);
        public Task<IEnumerable<LocationDto>> GetAllLocations();
        public Task<IEnumerable<QualificationDto>> GetAllQualifications();
        public Task<IEnumerable<TutorCategoryDto>> GetTutorCategories(string courseCategoryId);
        public Task<TutorCategoryDto> GetTutorCategory(string Id);
    }
}
