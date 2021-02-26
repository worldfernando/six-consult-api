using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SixConsultApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SixConsultApi.Dto.Customer;
using System.Net;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Helpers;
using Microsoft.AspNetCore.Http;
using SixConsultApi.Dto.Profile;
using Microsoft.AspNetCore.Authorization;

namespace SixConsultApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileController(IProfileService profileService, IUserService userService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._profileService = profileService;
            this._userService = userService;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Return list of customers
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(string filter, int? page, int? pageSize)
        {
            var query = _profileService.Query(filter);

            var totalItems = query.Count();

            if (page == null || pageSize == null)
            {
                return Ok(new
                {
                    items = _mapper.Map<List<ProfileDto>>(query.ToList()),
                    page = 1,
                    pageSize = 1,
                    totalCount = totalItems
                });
            }

            var totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize.Value);
            var startIndex = (page.Value - 1) * pageSize.Value;
            var items = query
                .Skip(startIndex)
                .Take(pageSize.Value)?
                .ToList();

            return Ok(new
            {
                items = _mapper.Map <List<ProfileDto>>(items),
                page = page.Value,
                pageSize = totalPages,
                totalCount = totalItems
            });
            
        }

        // GET api/<controller>/5
        /// <summary>
        /// Return Profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            return Ok(_mapper.Map<ProfileDto>(_profileService.GetById(id)));
        }

        // POST api/<controller>
        /// <summary>
        /// Create Profile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Post(ProfileDto profileDto)
        {
            try
            {
                var tools = new SixTools(_httpContextAccessor);
                var user = _userService.GetById(tools.GetUserTokenId());
                if (user == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não localizado" });
                if (!user.Profile.Create)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não possui permissão para realizar esta operacao" });
                var profile = new Domain.Entities.Profile(name: profileDto.Name, create: profileDto.Create, update: profileDto.Update, delete: profileDto.Delete, isAdmin: profileDto.IsAdmin);
                _profileService.Post(profile);
                return Ok(_mapper.Map<ProfileDto>(profile));
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = HttpStatusCode.PreconditionFailed, message = e.Message });
            }
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfileDto profileDto)
        {
            try
            {
                var tools = new SixTools(_httpContextAccessor);
                var user = _userService.GetById(tools.GetUserTokenId());
                if (user == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não localizado" });
                if (!user.Profile.Update)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não possui permissão para realizar esta operacao" });
                var profile = _profileService.GetById(id);
                if (profile == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Profile não localizado" });

                profile.Name = profileDto.Name;
                profile.Create = profileDto.Create;
                profile.Update = profileDto.Update;
                profile.Delete = profileDto.Delete;
                profile.IsAdmin = profileDto.IsAdmin;
                profile.UpdatedAt = DateTime.Now;

                _profileService.Update(profile);
                return Ok(_mapper.Map<ProfileDto>(profile));
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = HttpStatusCode.PreconditionFailed, message = e.Message });
            }
        }
    }
}
