using Models;

namespace TutorPins_Client.Service.IService
{
    public interface IQualificationService
    {
        public Task<IEnumerable<QualificationDto>> GetAllQualifications();
    }
}
