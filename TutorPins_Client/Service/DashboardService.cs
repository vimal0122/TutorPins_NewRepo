using DataAccess.Data;
using DataAccess.Migrations;
using Models;
using Newtonsoft.Json;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Service
{
	public class DashboardService : IDashboardService
	{
		private readonly HttpClient _client;
		public DashboardService(HttpClient client)
		{
			_client = client;
		}
		public async Task<spDashboardCountDto> GetDashboadCounts()
		{
			var response = await _client.GetAsync($"api/dashboard/GetDashboardCounts");
			var content = await response.Content.ReadAsStringAsync();
			var dashbooardCounts = JsonConvert.DeserializeObject<spDashboardCountDto>(content);
			return dashbooardCounts;
			//var response = await _client.GetAsync($"api/tutor/GetTutors");
			//return null;
		}
        public async Task<spTutorDashboardCountDto> GetTutorDashboardCounts(string tutorId)
        {            var response = await _client.GetAsync("api/dashboard/GetTutorDashboardCounts/" + tutorId);
            var content = await response.Content.ReadAsStringAsync();
            var dashbooardCounts = JsonConvert.DeserializeObject<spTutorDashboardCountDto>(content);
            return dashbooardCounts;            
        }
    }
}
