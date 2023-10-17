using BusinessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TutorPins_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DashboardController : ControllerBase
	{
		private readonly IDashboardRepository _Repository;
		public DashboardController(IDashboardRepository dashboardRepository)
		{
			_Repository = dashboardRepository;
		}
		[HttpGet]
		[Route("GetDashboardCounts")]
		public async Task<IActionResult> GetDashboardCounts()
		{
			var allObjects = await _Repository.GetDashboadCounts();
			return Ok(allObjects);
		}
	}
}
