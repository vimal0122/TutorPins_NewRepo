using BusinessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Formats.Asn1;

namespace TutorPins_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        public CourseCategoryController(ICourseCategoryRepository courseCategoryRepository)
        {
            _courseCategoryRepository = courseCategoryRepository;
        }

        [HttpGet]
        [Route("GetCourseCategories")]
        public async Task<IActionResult> GetCourseCategories()
        {
            var allCourseCategories = await _courseCategoryRepository.GetAllCourseCategories();
            return Ok(allCourseCategories);
        }
        [HttpPost]
        [Route("AddCourseCategory")]
        public async Task<CourseCategoryDto> AddCourseCategory([FromBody] CourseCategoryDto courseCategoryDto)
        {
            return await _courseCategoryRepository.CreateCourseCategory(courseCategoryDto);
        }
        [HttpGet("{id}")]
        public async Task<CourseCategoryDto> Get(int id)
        {
            return await _courseCategoryRepository.GetCourseCategory(id);
        }
    }
}
