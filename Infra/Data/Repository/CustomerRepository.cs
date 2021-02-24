using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Helpers;
using SixConsultApi.Infra.Data.Context;
using SixConsultApi.Infra.Data.Repository.interfaces;

namespace SixConsultApi.Infra.Data.Repository
{
    public class CustomerRepository<Customer> : BaseRepository<Customer>
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public CustomerRepository(ContextDB context, IMapper mapper, IOptions<AppSettings> appSettings) : base(context: context, mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }
    }
}
