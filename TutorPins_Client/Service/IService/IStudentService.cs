using Models;

namespace TutorPins_Client.Service.IService
{
    public interface IStudentService
    {
        public Task<bool> CreateStudent(StudentDto studentDto);
        public Task<StudentDto> UpdateStudent(int studentId, StudentDto studentDto);
        public Task<StudentDto> GetStudent(int studentId);
        public Task<IEnumerable<StudentDto>> GetAllStudents();
        public Task<IEnumerable<StudentDto>> GetStudentsBySubject(int subjectId);
        public Task<IEnumerable<StudentDto>> GetStudentsByStatus(string status);
        public Task<StudentSubjectDto> GetStudentSubject(string Id);
    }
}
