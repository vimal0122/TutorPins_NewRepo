using Models;
using Newtonsoft.Json;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Service
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _client;
        public LocationService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<LocationDto>> GetAllLocations()
        {
            var response = await _client.GetAsync($"api/masterdata/GetLocations");
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<LocationDto>>(content);
            return data;
        }
    }
}
