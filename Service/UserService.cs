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
using System;
using System.Linq;

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

        public User Delete(User objectInstance)
        {
            return _userRepository.Delete(objectInstance);
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public UserLoggedDto Login(LoginUserDto loginUserDto)
        {
            var user = _userRepository.GetByEmail(email: loginUserDto.email);
            if (user == null)
                return null;
            string passwordHash = _hashService.HashPassword(loginUserDto.password);
            bool valid = _hashService.Verify(loginUserDto.password, passwordHash);
            if (!valid)
                return null;
            var token = _jwtService.GenerateJwtToken(secret: _appSettings.Secret, claimId: user.Id.ToString(), user.Profile.IsAdmin);
            var userLogged = new UserLoggedDto(user.Id, Name: user.Name, Email: user.Email, Token: token.ToString(), user.Profile.IsAdmin);
            return userLogged;
        }

        public User Post(User objectInstance)
        {
            return _userRepository.Post(objectInstance);
        }

    public IQueryable<User> Query(string filter)
    {
      return _userRepository.Query(filter);
    }

    public UserDto Register(RegisterUserDto registerUserDto)
        {
            var user = _userRepository.GetByEmail(registerUserDto.Email);
            if (user != null)
                throw new SixBusinessException("Email já cadastrado");
            string passwordHash = _hashService.HashPassword(registerUserDto.Password);
            user = _userRepository.Post(new User(name: registerUserDto.Name, email: registerUserDto.Email, password: passwordHash, profileId: registerUserDto.ProfileId));
            Console.WriteLine(user.Id);
            return _mapper.Map<UserDto>(user);
        }

        public User Update(User objectInstance)
        {
            return _userRepository.Update(objectInstance);
        }
    }
}
