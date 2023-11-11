using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IRepository
{
    public interface IUserRepository
    {
        public UserDetailDto GetUserByEmail(string email);
        public UserDetailDto GetUser(string username,string pwd);
        public Task<IEnumerable<UserDetailDto>> GetUsers();
        public Task<UserDetailDto> CreateUser(UserDetailDto userDetailDto);
        public Task<UserDetailDto> UpdateUser(int userId, UserDetailDto userDetailDto);
    }
}
