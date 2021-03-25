using AuthServer.Dtos;
using AuthServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<User> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<object> RegistrationUser(RegistrationUserDto userDto)
        {
            userDto.Role = "user";
            User user = new User()
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                FullName = userDto.FullName,
            };

            try
            {
                var result = await _userManager.CreateAsync(user, userDto.Password);
                await _userManager.AddToRoleAsync(user, userDto.Role);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<string> Login(LoginUserDto userDto)
        {
            User user = await _userManager.FindByNameAsync(userDto.UserName);
            if (user != null && _userManager.CheckPasswordAsync(user, userDto.Password).Result)
            {
                var tokenString = await GenerateJWT(user);
                return tokenString;
            }
            else return null;
        }

        public async Task<string> GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var role = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("fullName", user.FullName),
                new Claim("role", role.FirstOrDefault()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
