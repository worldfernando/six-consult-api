using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Dto.User;
using SixConsultApi.Helpers;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService userService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._userService = userService;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
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
        [Authorize(Roles = "admin")]
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

        // GET api/<controller>/5
        /// <summary>
        /// Return User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public ObjectResult Get(int id)
        {
            return Ok(_mapper.Map<UserDto>(_userService.GetById(id)));
        }

        // POST api/<controller>
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost()]
        [Authorize(Roles = "admin")]
        public IActionResult Post(RegisterUserDto registerUserDto)
        {
            try
            {
                var tools = new SixTools(_httpContextAccessor);
                var user = _userService.GetById(tools.GetUserTokenId());
                if (user == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não localizado" });
                if (!user.Profile.Create)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não possui permissão para realizar esta operacao" });
                var newUser = new User(name: registerUserDto.Name, email: registerUserDto.Email, password: registerUserDto.Password, profileId: registerUserDto.ProfileId);
                _userService.Post(newUser);
                return Ok(_mapper.Map<UserDto>(newUser));
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = HttpStatusCode.PreconditionFailed, message = e.Message });
            }
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, RegisterUserDto registerUserDto)
        {
            try
            {
                var tools = new SixTools(_httpContextAccessor);
                var user = _userService.GetById(tools.GetUserTokenId());
                if (user == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não localizado" });
                if (!user.Profile.Update)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não possui permissão para realizar esta operacao" });
                var updateUser = _userService.GetById(id);
                if (updateUser == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não localizado" });

                updateUser.Name = registerUserDto.Name;
                updateUser.Email = registerUserDto.Email;
                updateUser.ProfileId = registerUserDto.ProfileId;
                updateUser.UpdatedAt = DateTime.Now;

                _userService.Update(updateUser);
                return Ok(_mapper.Map<UserDto>(updateUser));
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = HttpStatusCode.PreconditionFailed, message = e.Message });
            }
        }
    }
}
