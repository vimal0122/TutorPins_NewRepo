using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IRepository
{
    public interface ICourseCategoryRepository
    {
        public Task<CourseCategoryDto> CreateCourseCategory(CourseCategoryDto courseCategoryDto);
        public Task<CourseCategoryDto> UpdateCourseCategory(int courseCategoryId, CourseCategoryDto courseCategoryDto);
        public Task<CourseCategoryDto> GetCourseCategory(int courseCategoryId);
        public Task<IEnumerable<CourseCategoryDto>> GetAllCourseCategories();
        public Task<IEnumerable<LocationDto>> GetAllLocations();
        public Task<IEnumerable<QualificationDto>> GetAllQualifications();
        public Task<IEnumerable<TutorCategoryDto>> GetTutorCategories(int courseCategoryId);
        public Task<TutorCategoryDto> GetTutorCategory(int Id);

    }
}
