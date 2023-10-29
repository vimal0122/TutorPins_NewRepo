using DataAccess.Data;
using Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net;
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

            if (response.StatusCode == HttpStatusCode.BadRequest )
            {
                return false;
            }
                return true;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents()
        {
            var response = await _client.GetAsync($"api/student/GetStudents");
            var content = await response.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<IEnumerable<StudentDto>>(content);
            return students;
        }

        public async Task<IEnumerable<StudentDto>> GetMatchedStudents()
        {
            var response = await _client.GetAsync($"api/student/GetMatchedStudents");
            var content = await response.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<IEnumerable<StudentDto>>(content);
            return students;
        }

        public async Task<StudentDto> GetStudent(int studentId)
        {
            var response = await _client.GetAsync($"api/student/" + studentId.ToString());
            var content = await response.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<StudentDto>(content);
            return students;
        }

        public Task<IEnumerable<StudentDto>> GetStudentsByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentDto>> GetStudentsBySubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentSubjectDto> GetStudentSubject(string Id)
        {
            var response = await _client.GetAsync($"api/student/GetStudentSubject/" + Id);
            var content = await response.Content.ReadAsStringAsync();
            var objValues = JsonConvert.DeserializeObject<StudentSubjectDto>(content);
            return objValues;
        }

        public Task<StudentDto> UpdateStudent(int studentId, StudentDto studentDto)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<spGetStudentRequestLogDto>> GetStudentRequestLogs(StudentRequestLogRequest request)
        {
            var dataString = JsonConvert.SerializeObject(request);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync($"api/student/GetStudentRequestLogs", content);

            var dataContent = await response.Content.ReadAsStringAsync();
            var logs = JsonConvert.DeserializeObject<IEnumerable<spGetStudentRequestLogDto>>(dataContent);
            return logs;
        }
    }
}
