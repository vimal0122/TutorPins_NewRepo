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
	public class DashboardRepository : IDashboardRepository
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;
		public DashboardRepository(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<spDashboardCountDto> GetDashboadCounts()
		{
			await Task.Delay(1);
			try
			{
				var param = new SqlParameter[]
				{
				new SqlParameter(){ParameterName="@Id", SqlDbType=System.Data.SqlDbType.Int, Size=100, Direction=System.Data.ParameterDirection.Input,Value=DBNull.Value },

				};
				var list = _mapper.Map<IEnumerable<spDashboardCount>, IEnumerable<spDashboardCountDto>>(_db.Set<spDashboardCount>().FromSqlRaw("[dbo].[spDashboardCounts]", param));

				return list.FirstOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
			throw new NotImplementedException();
		}
        public async Task<spTutorDashboardCountDto> GetTutorDashboardCounts(int tutorId)
        {
            await Task.Delay(1);
            try
            {
                var param = new SqlParameter[]
                {
                new SqlParameter(){ParameterName="@Id", SqlDbType=System.Data.SqlDbType.Int, Size=100, Direction=System.Data.ParameterDirection.Input,Value=tutorId },

                };
                var list = _mapper.Map<IEnumerable<spTutorDashboardCount>, IEnumerable<spTutorDashboardCountDto>>(_db.Set<spTutorDashboardCount>().FromSqlRaw("[dbo].[spTutorDashboardCounts]", param));

                return list.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
            throw new NotImplementedException();
        }
    }
}
