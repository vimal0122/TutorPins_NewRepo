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
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CourseCategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CourseCategoryDto> CreateCourseCategory(CourseCategoryDto courseCategoryDto)
        {
            CourseCategory courseCategory = _mapper.Map<CourseCategoryDto, CourseCategory>(courseCategoryDto);
            courseCategory.CreatedDate = DateTime.Now;
            courseCategory.CreatedBy = "1";
            var addedCourseCategory = await _db.CourseCategories.AddAsync(courseCategory);
            await _db.SaveChangesAsync();
            return _mapper.Map<CourseCategory, CourseCategoryDto>(addedCourseCategory.Entity);
        }

        public async Task<IEnumerable<CourseCategoryDto>> GetAllCourseCategories()
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<CourseCategoryDto> courseDtos = _mapper.Map<IEnumerable<CourseCategory>, IEnumerable<CourseCategoryDto>>(_db.CourseCategories);
                return courseDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CourseCategoryDto> GetCourseCategory(int courseCategoryId)
        {
            try
            {
                CourseCategoryDto courseCategoryDto = _mapper.Map<CourseCategory, CourseCategoryDto>(await _db.CourseCategories.FirstOrDefaultAsync(x => x.Id == courseCategoryId));
                return courseCategoryDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CourseCategoryDto> UpdateCourseCategory(int courseCategoryId, CourseCategoryDto courseCategoryDto)
        {
            try
            {
                if (courseCategoryId == courseCategoryDto.Id)
                {
                    CourseCategory courseCategoryDetails = await _db.CourseCategories.FirstOrDefaultAsync(x => x.Id == courseCategoryId);
                    CourseCategory courseCategory = _mapper.Map<CourseCategoryDto, CourseCategory>(courseCategoryDto, courseCategoryDetails);
                    courseCategory.UpdatedDate = DateTime.Now;
                    courseCategory.UpdatedBy = "1";
                    var updatedCourseCategory = _db.CourseCategories.Update(courseCategory);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<CourseCategory, CourseCategoryDto>(updatedCourseCategory.Entity);
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
