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
    public class TutorRepository : ITutorRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public TutorRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<TutorDto> CreateTutor(TutorDto tutorDto)
        {
            try
            {
                Tutor tutor = _mapper.Map<TutorDto, Tutor>(tutorDto);
                
                tutor.CreatedDate = DateTime.Now;
                tutor.CreatedBy = "1";
                var addedTutor = await _db.Tutors.AddAsync(tutor);
                await _db.SaveChangesAsync();

                return _mapper.Map<Tutor, TutorDto>(addedTutor.Entity);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<IEnumerable<TutorDto>> GetAllTutors()
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<TutorDto> tutorDtos = _mapper.Map<IEnumerable<Tutor>, IEnumerable<TutorDto>>(_db.Tutors.Include(t=>t.TutorLocations).ThenInclude(x=>x.Location).Include(t=>t.TutorQualifications).ThenInclude(t=>t.Qualification).Include(t=>t.TutorSubjects).ThenInclude(x=>x.CourseSubject));
                
                return tutorDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TutorDto> GetTutor(int tutorId)
        {
            try
            {
                await Task.Delay(1);
                TutorDto tutorDtos = _mapper.Map<Tutor, TutorDto>( await _db.Tutors.Include(t => t.TutorLocations).ThenInclude(x => x.Location).Include(t => t.TutorQualifications).ThenInclude(t => t.Qualification).Include(t => t.TutorSubjects).ThenInclude(x => x.CourseSubject).FirstOrDefaultAsync(t => t.Id == tutorId));

                return tutorDtos;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<IEnumerable<TutorDto>> GetTutorsByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<spGetMatchedTutorDto>> GetTutorsBySubject(int Id)
        {
            await Task.Delay(1);
            try
            {
                var param = new SqlParameter[]
                {
                new SqlParameter(){ParameterName="@Id", SqlDbType=System.Data.SqlDbType.Int, Size=100, Direction=System.Data.ParameterDirection.Input,Value=Id },

                };
            //var list = await _db.Set<spGetMatchedTutor>().FromSqlRaw("[dbo].[spGetMatchedTutors]  @Id", param).ToListAsync();
            var list = _mapper.Map<IEnumerable<spGetMatchedTutor>, IEnumerable<spGetMatchedTutorDto>>(_db.Set<spGetMatchedTutor>().FromSqlRaw("[dbo].[spGetMatchedTutors]  @Id", param));
                
            return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<spGetMatchedTutorDto>> GetTutorsByFilters(FilterTutorRequest request)
        {
            await Task.Delay(1);
           
            try
            {
                var param = new SqlParameter[]
                {
                new SqlParameter(){ParameterName="@Id", SqlDbType=System.Data.SqlDbType.Int, Size=100, Direction=System.Data.ParameterDirection.Input,Value=request.Id },
                new SqlParameter() { ParameterName = "@FilterTutorCategoryId", SqlDbType = System.Data.SqlDbType.NVarChar, Size = 100, Direction = System.Data.ParameterDirection.Input, Value = string.IsNullOrWhiteSpace(request.FilterTutorCategoryId)?DBNull.Value:request.FilterTutorCategoryId },
                new SqlParameter() { ParameterName = "@FilterTutorGenderId", SqlDbType = System.Data.SqlDbType.NVarChar, Size = 100, Direction = System.Data.ParameterDirection.Input, Value = string.IsNullOrWhiteSpace(request.FilterTutorGenderId)?DBNull.Value:request.FilterTutorGenderId },
                new SqlParameter() { ParameterName = "@FilterRaceId", SqlDbType = System.Data.SqlDbType.NVarChar, Size = 100, Direction = System.Data.ParameterDirection.Input, Value = string.IsNullOrWhiteSpace(request.FilterRaceId)?DBNull.Value:request.FilterRaceId },
                new SqlParameter() { ParameterName = "@FilterRatingValue", SqlDbType = System.Data.SqlDbType.NVarChar, Size = 100, Direction = System.Data.ParameterDirection.Input, Value = string.IsNullOrWhiteSpace(request.FilterRatingValue)?DBNull.Value:request.FilterRatingValue },
                new SqlParameter() { ParameterName = "@FilterLocationId", SqlDbType = System.Data.SqlDbType.Int, Size = 100, Direction = System.Data.ParameterDirection.Input, Value = request.FilterLocationId.HasValue?request.FilterLocationId.Value:DBNull.Value },
                new SqlParameter() { ParameterName = "@FilterModeId", SqlDbType = System.Data.SqlDbType.NVarChar, Size = 100, Direction = System.Data.ParameterDirection.Input, Value = string.IsNullOrWhiteSpace(request.FilterModeId)?DBNull.Value:request.FilterModeId },
                new SqlParameter() { ParameterName = "@HourlyRateMinValue", SqlDbType = System.Data.SqlDbType.Int, Size = 100, Direction = System.Data.ParameterDirection.Input, Value = request.HourlyRateMinValue.HasValue?request.HourlyRateMinValue.Value:DBNull.Value },
                new SqlParameter() { ParameterName = "@HourlyRateMaxValue", SqlDbType = System.Data.SqlDbType.Int, Size = 100, Direction = System.Data.ParameterDirection.Input, Value = request.HourlyRateMaxValue.HasValue?request.HourlyRateMaxValue.Value:DBNull.Value },
            };
                
                var list = _mapper.Map<IEnumerable<spGetMatchedTutorsByFilter>, IEnumerable<spGetMatchedTutorDto>>(_db.Set<spGetMatchedTutorsByFilter>().FromSqlRaw("[dbo].[spGetMatchedTutorsByFilters]  @Id,@FilterTutorCategoryId,@FilterTutorGenderId,@FilterRaceId,@FilterRatingValue,@FilterLocationId,@FilterModeId,@HourlyRateMinValue,@HourlyRateMaxValue", param));
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        

        public async Task<bool> SaveMatchedTutor(SaveMatchedTutorRequest request)
        {
            await Task.Delay(1);
            try
            {
                var param = new SqlParameter[]
                {
                new SqlParameter(){ParameterName="@StudentSubjectId", SqlDbType=System.Data.SqlDbType.Int, Size=100, Direction=System.Data.ParameterDirection.Input,Value=request.StudentSubjectId },
                new SqlParameter(){ParameterName="@TutorId", SqlDbType=System.Data.SqlDbType.Int, Size=100, Direction=System.Data.ParameterDirection.Input,Value=request.TutorId > 0 ? request.TutorId : DBNull.Value },
                new SqlParameter(){ParameterName="@MatchStatusId", SqlDbType=System.Data.SqlDbType.Int, Size=100, Direction=System.Data.ParameterDirection.Input,Value=request.MatchStatusId },
				new SqlParameter(){ParameterName="@Remarks", SqlDbType=System.Data.SqlDbType.NVarChar, Size=2000, Direction=System.Data.ParameterDirection.Input,Value=string.IsNullOrEmpty(request.AdminRemarks)?"":request.AdminRemarks },
				new SqlParameter(){ParameterName="@UserId", SqlDbType=System.Data.SqlDbType.Int, Size=100, Direction=System.Data.ParameterDirection.Input,Value=request.UserId },

                };                
                await _db.Database.ExecuteSqlRawAsync("[dbo].[spSaveMatchedTutors] @StudentSubjectId, @TutorId,@MatchStatusId,@Remarks,@UserId", param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<TutorDto> UpdateTutor(int tutorId, TutorDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
