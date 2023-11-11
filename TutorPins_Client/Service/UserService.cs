using Models;
using Newtonsoft.Json;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserDetailDto> CreateUser(UserDetailDto userDetailDto)
        {
            userDetailDto.CreatedDate = DateTime.Now;
            userDetailDto.UpdatedDate = DateTime.Now;
            var dataString = JsonConvert.SerializeObject(userDetailDto);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync($"api/user/AddUser", content);
            var content1 = await response.Content.ReadAsStringAsync();
            var userData = JsonConvert.DeserializeObject<UserDetailDto>(content1);
            return userData;
        }

        public async Task<UserDetailDto> GetUserByEmail(string email)
        {
            var response = await _client.GetAsync("api/user/GetUser/" + email);
            var content = await response.Content.ReadAsStringAsync();
            var userData = JsonConvert.DeserializeObject<UserDetailDto>(content);
            return userData;
        }

        public async Task<IEnumerable<UserDetailDto>> GetUsers()
        {
            var response = await _client.GetAsync($"api/user/GetUsers");
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<UserDetailDto>>(content);
            return data;
        }

        public Task<UserDetailDto> UpdateUser(int userId, UserDetailDto userDetailDto)
        {
            throw new NotImplementedException();
        }
    }
}
