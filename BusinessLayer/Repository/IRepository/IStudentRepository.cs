using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IRepository
{
    public interface IStudentRepository
    {
        public Task<StudentDto> CreateStudent(StudentDto studentDto);
        public Task<StudentDto> UpdateStudent(int studentId, StudentDto studentDto);
        public Task<StudentDto> GetStudent(int studentId);
        public Task<IEnumerable<StudentDto>> GetAllStudents();
        public Task<IEnumerable<StudentDto>> GetStudentsBySubject(int subjectId);
        public Task<IEnumerable<StudentDto>> GetStudentsByStatus(string status);
        public Task<StudentSubjectDto> GetStudentSubject(int Id);
        public Task<IEnumerable<StudentDto>> GetMatchedStudents();
        public Task<IEnumerable<spGetStudentRequestLogDto>> GetStudentRequestLogs(StudentRequestLogRequest request);
    }
}
