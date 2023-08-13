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
    }
}
