﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Helpers;
using SixConsultApi.Infra.Data.Context;
using SixConsultApi.Infra.Data.Repository.interfaces;
using System;
using System.Linq;

namespace SixConsultApi.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<Domain.Entities.User>, IUserRepository
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserRepository(ContextDB context, IMapper mapper, IOptions<AppSettings> appSettings) : base(context: context, mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        public User GetByEmail(string email)
        {
            return _context.User.AsQueryable().Include(x => x.Profile).Where(x => x.Email == email).FirstOrDefault();
        }

        public Domain.Entities.User GetByEmailAndPassword(string email, string password)
        {
            return _context.User.AsQueryable().Include(x => x.Profile).Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}
