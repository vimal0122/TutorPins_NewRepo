using Models;
using Newtonsoft.Json;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Service
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _client;
        public StudentService(HttpClient client)
        {
            _client = client;
        }
        public async Task<bool> CreateStudent(StudentDto studentDto)
        {
            var dataString = JsonConvert.SerializeObject(studentDto);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync($"api/student/AddStudent", content);
            return true;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents()
        {
            var response = await _client.GetAsync($"api/student/GetStudents");
            var content = await response.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<IEnumerable<StudentDto>>(content);
            return students;
        }

        public Task<StudentDto> GetStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentDto>> GetStudentsByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentDto>> GetStudentsBySubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<StudentDto> UpdateStudent(int studentId, StudentDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
