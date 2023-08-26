using Models;
using Newtonsoft.Json;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Service
{
    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly HttpClient _client;
        public CourseCategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> CreateCourseCategory(CourseCategoryDto courseCategoryDto)
        {
            var dataString = JsonConvert.SerializeObject(courseCategoryDto);    
            var content = new StringContent(dataString);
            content.Headers.ContentType= new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync($"api/coursecategory/AddCourseCategory", content);
            return true;
        }

        public async Task<IEnumerable<CourseCategoryDto>?> GetCourseCategories()
        {
            var response = await _client.GetAsync($"api/coursecategory/GetCourseCategories");
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<CourseCategoryDto>>(content);
            return data;
        }

        public Task<CourseCategoryDto> GetCourseCategory(int courseCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<CourseCategoryDto> UpdateCourseCategory(int courseCategoryId, CourseCategoryDto courseCategoryDto)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<LocationDto>> GetAllLocations()
        {
            var response = await _client.GetAsync($"api/coursecategory/GetLocations");
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<LocationDto>>(content);
            return data;
        }
        public async Task<IEnumerable<QualificationDto>> GetAllQualifications()
        {
            var response = await _client.GetAsync($"api/coursecategory/GetQualifications");
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<QualificationDto>>(content);
            return data;
        }
    }
}
