using AutoMapper;
using SixConsultApi.Service.Interfaces;
using SixConsultApi.Dto.User;
using SixConsultApi.Helpers;
using Microsoft.Extensions.Options;
using SixConsultApi.Infra.Data.Repository;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Infra.Data.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;
using SixConsultApi.Helpers.Interfaces;

namespace SixConsultApi.Service
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IHashService _hashService;

        public UserService(IUserRepository userRepository, IJwtService jwtService, IHashService hashService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _jwtService = jwtService;
            _hashService = hashService;
            _userRepository = userRepository;
        }

        public UserLoggedDto Login(LoginUserDto loginUserDto)
        {
            string passwordHash = _hashService.HashPassword(loginUserDto.password);
            var user = _userRepository.GetByEmailAndPassword(email: loginUserDto.email, password: passwordHash);
            if (user == null) 
            {
                return null;
            }
            var token = _jwtService.GenerateJwtToken(secret: _appSettings.Secret, claimId: user.Id.ToString());
            var userLogged = new UserLoggedDto(Name: user.Name, Email: user.Email, Token: token.ToString());
            return userLogged;
        }

        public UserDto Register(RegisterUserDto registerUserDto)
        {
            string passwordHash = _hashService.HashPassword(registerUserDto.Password);
            var user = _userRepository.Post(new User(name: registerUserDto.Name, email: registerUserDto.Email, password: passwordHash));
            return _mapper.Map<UserDto>(user);
        }
    }
}
