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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public CustomerRepository(ContextDB context, IMapper mapper, IOptions<AppSettings> appSettings) : base(context: context, mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        override
        public Customer GetById(long id)
        {
            return _context.Customer.AsQueryable().Include(x => x.UserCreated).Include(x => x.UserUpdated).Where(x => x.Id == id).FirstOrDefault();
        }

        override
        public IQueryable<Customer> Query(string filter){
            var query = _context.Customer.AsQueryable().Include(x => x.UserCreated).Include(x => x.UserUpdated).AsQueryable();

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
