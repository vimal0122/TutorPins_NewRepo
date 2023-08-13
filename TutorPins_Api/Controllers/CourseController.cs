using BusinessLayer.Repository;
using BusinessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TutorPins_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        
        [HttpGet]
        [Route("GetCourses")]
        public async Task<IActionResult> GetCourses()
        {
            var allCourses =  await _courseRepository.GetAllCourses();
            return Ok(allCourses);
        }
        [HttpPost]
        [Route("AddCourse")]
        public async Task<CourseDto> AddCourse([FromBody] CourseDto courseDto)
        {
            return await _courseRepository.CreateCourse(courseDto);
        }
        [HttpGet("{id}")]
        public async Task<CourseDto> Get(int id)
        {
            return await _courseRepository.GetCourse(id);
        }
        [HttpGet]
        [Route("GetCourseByCategory/{id}")]
        public async Task<IEnumerable<CourseDto>> GetCourseByCategory(string id)
        {
            return await _courseRepository.GetCoursesByCategory(Convert.ToInt32(id));
        }
    }
}
