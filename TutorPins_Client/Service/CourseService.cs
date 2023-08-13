using Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Service
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient _client;
        public CourseService(HttpClient client)
        {
                _client = client;
        }

        public async Task<bool> CreateCourse(CourseDto courseDto)
        {
            var dataString = JsonConvert.SerializeObject(courseDto);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync($"api/course/AddCourse", content);
            return true;
        }

        public async Task<IEnumerable<CourseDto>> GetCourses()
        {
            var response = await _client.GetAsync($"api/course/GetCourses");
            var content = await response.Content.ReadAsStringAsync();
            var courses= JsonConvert.DeserializeObject<IEnumerable<CourseDto>>(content);
            return courses;
        }
        public async Task<IEnumerable<CourseDto>> GetCoursesByCategory(string categoryId)
        {
            var response = await _client.GetAsync("api/course/GetCourseByCategory/" + categoryId);
            var content = await response.Content.ReadAsStringAsync();
            var courses = JsonConvert.DeserializeObject<IEnumerable<CourseDto>>(content);
            return courses;
        }
    }
}
