using BusinessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TutorPins_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IQualificationRepository _qualificationRepository;
        private readonly ILocationRepository _locationRepository;
        public MasterDataController(IQualificationRepository qualificationRepository, ILocationRepository locationRepository)
        {
            _qualificationRepository = qualificationRepository;
            _locationRepository = locationRepository;
        }

        [HttpGet]
        [Route("GetLocations")]
        public async Task<IActionResult> GetLocations()
        {
            var allLocations = await _locationRepository.GetAllLocations();
            return Ok(allLocations);
        }
        [HttpGet]
        [Route("GetQualifications")]
        public async Task<IActionResult> GetQualifications()
        {
            var allLocations = await _qualificationRepository.GetAllQualifications  ();
            return Ok(allLocations);
        }
    }
}
