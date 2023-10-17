using Models;

namespace TutorPins_Client.Service.IService
{
	public interface IDashboardService
	{
		public Task<spDashboardCountDto> GetDashboadCounts();
	}
}
