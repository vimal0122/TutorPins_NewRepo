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
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CourseRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db; 
            _mapper = mapper;
        }
        public async Task<CourseDto> CreateCourse(CourseDto courseDto)
        {
            Course course = _mapper.Map<CourseDto,Course>(courseDto);
            course.CreatedDate = DateTime.Now;
            course.CreatedBy = "1";
            var addedCourse = await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            return _mapper.Map<Course, CourseDto>(addedCourse.Entity);
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<CourseDto> courseDtos = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(_db.Courses.Include(x=>x.CourseCategory));
                return courseDtos;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<CourseDto> GetCourse(int courseId)
        {
            try
            {
                CourseDto courseDto = _mapper.Map<Course, CourseDto>(await _db.Courses.FirstOrDefaultAsync(x=>x.Id==courseId));
                return courseDto;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<CourseDto> IsCourseUnique(string courseName)
        {
            try
            {
                CourseDto courseDto = _mapper.Map<Course, CourseDto>(await _db.Courses.FirstOrDefaultAsync(x => x.CourseName.ToLower() == courseName.ToLower()));
                return courseDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CourseDto> UpdateCourse(int courseId, CourseDto courseDto)
        {
            try
            {
                if (courseId == courseDto.Id)
                {
                    Course courseDetails = await _db.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
                    Course course = _mapper.Map<CourseDto,Course>(courseDto, courseDetails);
                    course.UpdatedDate = DateTime.Now;
                    course.UpdatedBy = "1";
                    var updatedCourse = _db.Courses.Update(course);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Course, CourseDto>(updatedCourse.Entity);
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
        public async Task<IEnumerable<CourseDto>> GetCoursesByCategory(int categoryId)
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<CourseDto> courseDtos = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(_db.Courses.Include(x => x.CourseCategory).Where(t => t.CourseCategoryId==categoryId));
                return courseDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
