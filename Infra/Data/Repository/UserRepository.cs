using AutoMapper;
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
            return _context.User.AsQueryable().Include(x => x.Profile).Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public Domain.Entities.User GetByEmailAndPassword(string email, string password)
        {
            return _context.User.AsQueryable().Include(x => x.Profile).Where(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();
        }

        override
        public Domain.Entities.User GetById(long id)
        {
            return _context.User.AsQueryable().Include(x => x.Profile).Where(x => x.Id == id).FirstOrDefault();
        }

        override
        public IQueryable<Domain.Entities.User> Query(string filter){
            var query = _context.User.AsQueryable().Include(x => x.Profile).AsQueryable();

            if (!String.IsNullOrEmpty(filter))
            {
                filter = filter.ToUpper();
                query = query.Where(b => b.Name.ToLower().Contains(filter.ToLower()));
            }
            query = query.OrderBy(b => b.Name);

            return query;
        }
    }
}
