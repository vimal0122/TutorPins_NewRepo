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
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public LocationRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LocationDto>> GetAllLocations()
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<LocationDto> courseDtos = _mapper.Map<IEnumerable<Location>, IEnumerable<LocationDto>>(_db.Locations);
                return courseDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
