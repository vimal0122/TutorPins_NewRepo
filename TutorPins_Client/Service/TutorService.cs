using Models;
using Newtonsoft.Json;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Service
{
    public class TutorService : ITutorService
    {
        private readonly HttpClient _client;
        public TutorService(HttpClient client)
        {
            _client = client;
        }
        public async Task<bool> CreateTutor(TutorDto tutorDto)
        {
            var dataString = JsonConvert.SerializeObject(tutorDto);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync($"api/tutor/AddTutor", content);
            return true;
        }

        public async Task<IEnumerable<TutorDto>> GetAllTutors()
        {
            var response = await _client.GetAsync($"api/tutor/GetTutors");
            var content = await response.Content.ReadAsStringAsync();
            var tutors = JsonConvert.DeserializeObject<IEnumerable<TutorDto>>(content);
            return tutors;
        }

        public Task<TutorDto> GetTutor(int tutorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TutorDto>> GetTutorsByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TutorDto>> GetTutorsBySubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<TutorDto> UpdateTutor(int tutorId, TutorDto tutorDto)
        {
            throw new NotImplementedException();
        }
    }
}
