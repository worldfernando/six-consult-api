using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Helpers;
using SixConsultApi.Infra.Data.Context;
using SixConsultApi.Infra.Data.Repository.interfaces;

namespace SixConsultApi.Infra.Data.Repository
{
    public class CustomerRepository<Customer> : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public CustomerRepository(ContextDB context, IMapper mapper, IOptions<AppSettings> appSettings) : base(context: context, mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        public void AfterDelete(Domain.Entities.Customer objectInstance)
        {
            throw new System.NotImplementedException();
        }

        public void AfterPost(Domain.Entities.Customer objectInstance)
        {
            throw new System.NotImplementedException();
        }

        public void AfterUpdate(Domain.Entities.Customer objectInstance)
        {
            throw new System.NotImplementedException();
        }

        public void BeforeDelete(Domain.Entities.Customer objectInstance)
        {
            throw new System.NotImplementedException();
        }

        public void BeforePost(Domain.Entities.Customer objectInstance)
        {
            throw new System.NotImplementedException();
        }

        public void BeforeUpdate(Domain.Entities.Customer objectInstance)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Entities.Customer Delete(Domain.Entities.Customer objectInstance)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Entities.Customer Post(Domain.Entities.Customer objectInstance)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Entities.Customer Update(Domain.Entities.Customer objectInstance)
        {
            throw new System.NotImplementedException();
        }

        Domain.Entities.Customer IRepository<Domain.Entities.Customer>.GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
