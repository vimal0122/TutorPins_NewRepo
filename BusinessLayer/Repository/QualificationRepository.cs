using AutoMapper;
using BusinessLayer.Repository.IRepository;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public QualificationRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<QualificationDto>> GetAllQualifications()
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<QualificationDto> objectDtos = _mapper.Map<IEnumerable<Qualification>, IEnumerable<QualificationDto>>(_db.Qualifications);
                return objectDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
