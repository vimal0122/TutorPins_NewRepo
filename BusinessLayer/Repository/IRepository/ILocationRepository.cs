using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IRepository
{
    public interface ILocationRepository
    {
        public Task<IEnumerable<LocationDto>> GetAllLocations();
    }
}
