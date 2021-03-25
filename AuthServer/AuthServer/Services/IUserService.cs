using AuthServer.Dtos;
using AuthServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Services
{
    public interface IUserService
    {
        Task<object> RegistrationUser(RegistrationUserDto user);
        Task<string> Login(LoginUserDto userDto);
        Task<string> GenerateJWT(User userInfo);
    }
}
