using Models;

namespace TutorPins_Client.Service.IService
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationDto>> GetAllLocations();
    }
}
