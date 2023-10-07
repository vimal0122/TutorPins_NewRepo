using BusinessLayer.Repository;
using BusinessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TutorPins_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorRepository _Repository;
        public TutorController(ITutorRepository tutorRepository)
        {
            _Repository = tutorRepository;
        }
        [HttpGet]
        [Route("GetTutors")]
        public async Task<IActionResult> GetTutors()
        {
            var allObjects = await _Repository.GetAllTutors();
            return Ok(allObjects);
        }
        [HttpPost]
        [Route("AddTutor")]
        public async Task<TutorDto> AddTutor([FromBody] TutorDto objectDto)
        {
            return await _Repository.CreateTutor(objectDto);
        }
        [HttpGet]
        [Route("GetTutorsBySubject/{id}")]
        public async Task<IEnumerable<spGetMatchedTutorDto>> GetTutorsBySubject(string id)
        {
            return await _Repository.GetTutorsBySubject(Convert.ToInt32(id));
        }
        [HttpPost]
        [Route("SaveMatchedTutor")]
        public async Task<bool> SaveMatchedTutor([FromBody] SaveMatchedTutorRequest request)
        {
            return await _Repository.SaveMatchedTutor(request);
        }
        [HttpGet("{id}")]
        public async Task<TutorDto> Get(string id)
        {
            return await _Repository.GetTutor(Convert.ToInt32(id));
        }
    }
}
