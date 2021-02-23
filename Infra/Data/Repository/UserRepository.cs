using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SixConsultApi.Helpers;
using SixConsultApi.Infra.Data.Context;
using SixConsultApi.Infra.Data.Repository.interfaces;
using System;
using System.Linq;

namespace SixConsultApi.Infra.Data.Repository
{
    public class UserRepository<User> : BaseRepository<User>, IUserRepository
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserRepository(ContextDB context, IMapper mapper, IOptions<AppSettings> appSettings) : base(context: context, mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        public void AfterDelete(Domain.Entities.User objectInstance)
        {
            throw new NotImplementedException();
        }

        public void AfterPost(Domain.Entities.User objectInstance)
        {
            throw new NotImplementedException();
        }

        public void AfterUpdate(Domain.Entities.User objectInstance)
        {
            throw new NotImplementedException();
        }

        public void BeforeDelete(Domain.Entities.User objectInstance)
        {
            throw new NotImplementedException();
        }

        public void BeforePost(Domain.Entities.User objectInstance)
        {
            throw new NotImplementedException();
        }

        public void BeforeUpdate(Domain.Entities.User objectInstance)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.User Delete(Domain.Entities.User objectInstance)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.User GetByEmailAndPassword(string email, string password)
        {
            return _context.User.AsQueryable().Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public Domain.Entities.User Post(Domain.Entities.User objectInstance)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.User Update(Domain.Entities.User objectInstance)
        {
            throw new NotImplementedException();
        }

        Domain.Entities.User IRepository<Domain.Entities.User>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
