using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixConsultApi.Dto.User;
using SixConsultApi.Service;
using SixConsultApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SixConsultApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// Parameters:
        ///
        ///     POST /login
        ///     {
        ///        "email": "",
        ///        "password": ""
        ///     }
        ///
        /// </remarks>
        /// <param name="userParam"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LoginUserDto loginUserDto)
        {
            var user = _userService.Login(loginUserDto);

            if (user == null)
                return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário e senha inválidos" });

            return Ok(_mapper.Map<UserLoggedDto>(user));
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <remarks>
        /// Parameters:
        ///
        ///     POST /register
        ///     {
        ///        "name":"", 
        ///        "email": "",
        ///        "password": ""
        ///     }
        ///
        /// </remarks>
        /// <param name="userParam"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                var user = _userService.Register(registerUserDto);

                if (user == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não registrado" });

                return Ok(_mapper.Map<UserDto>(user));
            } catch (Exception e)
            {
                return BadRequest(new { StatusCode = HttpStatusCode.PreconditionFailed, message = e.Message });
            }
            
            
        }
    }
}
