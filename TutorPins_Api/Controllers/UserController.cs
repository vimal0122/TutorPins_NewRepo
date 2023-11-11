using BusinessLayer.Repository;
using BusinessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TutorPins_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [Route("GetUser/{emailid}")]
        public  UserDetailDto GetUser(string emailid)
        {
            return  _userRepository.GetUserByEmail(emailid);
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var allUsers = await _userRepository.GetUsers();
            return Ok(allUsers);
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<UserDetailDto> AddUser([FromBody] UserDetailDto userDetailDto)
        {
            return await _userRepository.CreateUser(userDetailDto);
        }
    }
}
