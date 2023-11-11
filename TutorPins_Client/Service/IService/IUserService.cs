using Models;

namespace TutorPins_Client.Service.IService
{
    public interface IUserService
    {
        public Task<UserDetailDto> GetUserByEmail(string email);
        public Task<IEnumerable<UserDetailDto>> GetUsers();
        public Task<UserDetailDto> CreateUser(UserDetailDto userDetailDto);
        public Task<UserDetailDto> UpdateUser(int userId, UserDetailDto userDetailDto);
    }
}
