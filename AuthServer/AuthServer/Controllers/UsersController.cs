using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthServer.Models;
using AuthServer.Services;
using AuthServer.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace AuthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("registration")]
        //POST : /api/Users/registration
        public async Task<object> Registration(RegistrationUserDto userDto)
        {
            var result = await _userService.RegistrationUser(userDto);
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        //POST : /api/Users/login
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
        {
            IActionResult response = Unauthorized();
            var token = await _userService.Login(userDto);
            if (token != null)
            {
                response = Ok(new { token });
            }
            return response;
        }
    }
}
