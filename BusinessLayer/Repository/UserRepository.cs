using AutoMapper;
using BusinessLayer.Repository.IRepository;
using DataAccess.Data;
using DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UserDetailDto> CreateUser(UserDetailDto userDetailDto)
        {
            UserDetail userDetail = _mapper.Map<UserDetailDto, UserDetail>(userDetailDto);
            userDetail.CreatedDate = DateTime.Now;
            userDetail.CreatedBy = "1";
            userDetail.UpdatedDate=DateTime.Now;
            userDetail.UpdatedBy = "1";
            userDetail.UserPassword = "password";
            userDetail.PasswordChangeCount = 0;
            var addedUser = await _db.UserDetails.AddAsync(userDetail);
            await _db.SaveChangesAsync();
            return _mapper.Map<UserDetail, UserDetailDto>(addedUser.Entity);
        }

        public UserDetailDto GetUser(string username, string pwd)
        {
            try
            {
                UserDetailDto userDetailDto = _mapper.Map<UserDetail, UserDetailDto>(_db.UserDetails.FirstOrDefault(x => x.EmailId.Equals(username) && x.UserPassword.Equals(pwd)));
                return userDetailDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UserDetailDto GetUserByEmail(string email)
        {
            try
            {
                UserDetailDto userDetailDto = _mapper.Map<UserDetail, UserDetailDto>( _db.UserDetails.FirstOrDefault(x => x.EmailId.Equals(email)));
                return userDetailDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserDetailDto>> GetUsers()
        {
            try
            {
                await Task.Delay(1);
                IEnumerable<UserDetailDto> users = _mapper.Map<IEnumerable<UserDetail>, IEnumerable<UserDetailDto>>(_db.UserDetails);
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserDetailDto> UpdateUser(int userId, UserDetailDto userDetailDto)
        {
            try
            {
                if (userId == userDetailDto.Id)
                {
                    UserDetail userDetails = await _db.UserDetails.FirstOrDefaultAsync(x => x.Id == userId);
                    UserDetail user = _mapper.Map<UserDetailDto, UserDetail>(userDetailDto, userDetails);
                    user.UpdatedDate = DateTime.Now;
                    user.UpdatedBy = "1";
                    var updatedUser = _db.UserDetails.Update(user);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<UserDetail, UserDetailDto>(updatedUser.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
