using BusinessLayer.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TutorPins_Api.Authentication
{
    public class JwtAuthenticationManager
    {
        public const string JWT_SECURITY_KEY = "c103caa346bb48868bece4e121ad9a34";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private IUserRepository _userRepository;
        public JwtAuthenticationManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserSession GenerateJwtToken(string username, string password)
        {
            if(string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            /* Validating the user credentials */
            var userAccount = _userRepository.GetUserByEmail(username);
            if(userAccount == null || userAccount.UserPassword != password) 
            {
                return null;
            }

            /*Generating JWT Token */
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role,userAccount.RoleId)
            });
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            var userSession = new UserSession
            {
                UserName = username,
                Role = userAccount.RoleId,
                Token = token,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
            return userSession;
        }
    }
}
