using BusinessLayer.Repository;
using BusinessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TutorPins_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSubjectController : ControllerBase
    {
        private readonly ICourseSubjectRepository _courseSubjectRepository;
        public CourseSubjectController(ICourseSubjectRepository courseSubjectRepository)
        {
            _courseSubjectRepository = courseSubjectRepository;
        }
        [HttpGet]
        [Route("GetCourseSubjects")]
        public async Task<IActionResult> GetCourseSubjects()
        {
            var allCourses = await _courseSubjectRepository.GetAllSubjects();
            return Ok(allCourses);
        }
        [HttpPost]
        [Route("AddCourseSubject")]
        public async Task<CourseSubjectDto> AddCourse([FromBody] CourseSubjectDto courseSubjectDto)
        {
            return await _courseSubjectRepository.CreateSubject(courseSubjectDto);
        }
        [HttpGet("{id}")]
        public async Task<CourseSubjectDto> Get(int id)
        {
            return await _courseSubjectRepository.GetSubject(id);
        }
        [HttpGet]
        [Route("GetSubjectsByCourse/{id}")]
        public async Task<IEnumerable<CourseSubjectDto>> GetSubjectsByCourse(string id)
        {
            return await _courseSubjectRepository.GetSubjectsByCourse(Convert.ToInt32(id));
        }
    }
}
