using Models;
using Newtonsoft.Json;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Service
{
    public class QualificationService : IQualificationService
    {
        private readonly HttpClient _client;
        public QualificationService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<QualificationDto>> GetAllQualifications()
        {
            var response = await _client.GetAsync($"api/masterdata/GetQualifications");
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<QualificationDto>>(content);
            return data;
        }
    }
}
