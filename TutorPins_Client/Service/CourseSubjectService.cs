using DataAccess.Data;
using Models;
using Newtonsoft.Json;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Service
{
    public class CourseSubjectService : ICourseSubjectService
    {
        private readonly HttpClient _client;
        public CourseSubjectService(HttpClient client)
        {
            _client = client;
        }
        public async Task<bool> CreateCourseSubject(CourseSubjectDto courseSubjectDto)
        {
            var dataString = JsonConvert.SerializeObject(courseSubjectDto);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync($"api/coursesubject/AddCourseSubject", content);
            return true;
        }

        public async Task<IEnumerable<CourseSubjectDto>> GetCourseSubjects()
        {
            var response = await _client.GetAsync($"api/coursesubject/GetCourseSubjects/");
            var content = await response.Content.ReadAsStringAsync();
            var courseSubjects = JsonConvert.DeserializeObject<IEnumerable<CourseSubjectDto>>(content);
            return courseSubjects;
        }

        public async Task<IEnumerable<CourseSubjectDto>> GetSubjectsByCourse(string courseId)
        {
            var response = await _client.GetAsync($"api/coursesubject/GetSubjectsByCourse/" + courseId);
            var content = await response.Content.ReadAsStringAsync();
            var courseSubjects = JsonConvert.DeserializeObject<IEnumerable<CourseSubjectDto>>(content);
            return courseSubjects;
        }

        public async Task<IEnumerable<CourseSubjectDto>> GetSubjectsByCourseCategory(string courseCategoryId)
        {
            var response = await _client.GetAsync($"api/coursesubject/GetSubjectsByCourseCategory/" + courseCategoryId);
            var content = await response.Content.ReadAsStringAsync();
            var courseSubjects = JsonConvert.DeserializeObject<IEnumerable<CourseSubjectDto>>(content);
            return courseSubjects;
        }
    }
}
