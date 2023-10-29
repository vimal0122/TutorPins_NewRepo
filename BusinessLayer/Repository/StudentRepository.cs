using AutoMapper;
using BusinessLayer.Repository.IRepository;
using DataAccess.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public StudentRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<StudentDto> CreateStudent(StudentDto studentDto)
        {
            try
            {
                Student student = _mapper.Map<StudentDto, Student>(studentDto);
                student.CreatedDate = DateTime.Now;
                student.StudentStatus = "Requested";
                student.CreatedBy = "1";
                var addedStudent = await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
            
            return _mapper.Map<Student, StudentDto>(addedStudent.Entity);
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents()
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<StudentDto> studentDtos = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(_db.Students.Where(t=>t.StudentStatus != "Matched").Include(t => t.StudentLocations).ThenInclude(x => x.Location).Include(t => t.StudentSubjects).ThenInclude(x => x.CourseSubject));
                /*
                using (var sequenceEnum = studentDtos.GetEnumerator())
                {
                    while (sequenceEnum.MoveNext())
                    {
                        // Do something with sequenceEnum.Current.
                        int c = sequenceEnum.Current.StudentSubjects.Count();
                        int m = sequenceEnum.Current.StudentSubjects.Where(t=>t.TutorMatched==true).Count();
                        sequenceEnum.Current.MatchStatus = string.Format("{0}/{1}", m.ToString(), c.ToString());
                    }
                }
                */
                return studentDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<StudentDto>> GetMatchedStudents()
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<StudentDto> studentDtos = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(_db.Students.Where(t => t.StudentStatus == "Matched").Include(t => t.StudentLocations).ThenInclude(x => x.Location).Include(t => t.StudentSubjects).ThenInclude(x => x.CourseSubject));
                /*
                using (var sequenceEnum = studentDtos.GetEnumerator())
                {
                    while (sequenceEnum.MoveNext())
                    {
                        // Do something with sequenceEnum.Current.
                        int c = sequenceEnum.Current.StudentSubjects.Count();
                        int m = sequenceEnum.Current.StudentSubjects.Where(t=>t.TutorMatched==true).Count();
                        sequenceEnum.Current.MatchStatus = string.Format("{0}/{1}", m.ToString(), c.ToString());
                    }
                }
                */
                return studentDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<StudentDto> GetStudent(int studentId)
        {
            try
            {                
                StudentDto studentDto = _mapper.Map<Student, StudentDto>(await _db.Students.Include(t => t.StudentLocations.Where(s=>s.IsActive==true)).ThenInclude(x => x.Location).Include(t => t.StudentSubjects).ThenInclude(x => x.CourseSubject).FirstOrDefaultAsync(t=>t.Id==studentId));
                return studentDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsByStatus(string status)
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<StudentDto> studentDtos = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(_db.Students.Where(t=>t.StudentStatus==status));
                return studentDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<IEnumerable<StudentDto>> GetStudentsBySubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentSubjectDto> GetStudentSubject(int Id)
        {
            try
            {
                StudentSubjectDto objDto = _mapper.Map<StudentSubject, StudentSubjectDto>(await _db.StudentSubjects.Include(t => t.Student).ThenInclude(t => t.StudentLocations.Where(s => s.IsActive == true)).ThenInclude(d=>d.Location).Include(x=>x.CourseSubject).ThenInclude(t=>t.Course).ThenInclude(t => t.CourseCategory).FirstOrDefaultAsync(t => t.Id == Id));
                return objDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<StudentDto> UpdateStudent(int studentId, StudentDto studentDto)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<spGetStudentRequestLogDto>> GetStudentRequestLogs(StudentRequestLogRequest request)
        {
            await Task.Delay(1);

            try
            {
                var param = new SqlParameter[]
                {
                new SqlParameter(){ParameterName="@StudentSubjectId", SqlDbType=System.Data.SqlDbType.Int, Size=100, Direction=System.Data.ParameterDirection.Input,Value=request.StudentSubjectId },                
                new SqlParameter() { ParameterName = "@TutorId", SqlDbType = System.Data.SqlDbType.Int, Size = 100, Direction = System.Data.ParameterDirection.Input, Value = request.TutorId },
                
            };

                var list = _mapper.Map<IEnumerable<spGetStudentRequestLog>, IEnumerable<spGetStudentRequestLogDto>>(_db.Set<spGetStudentRequestLog>().FromSqlRaw("[dbo].[spGetStudentRequestLogs]  @StudentSubjectId,@TutorId", param));
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
