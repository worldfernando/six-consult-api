using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Helpers;
using SixConsultApi.Infra.Data.Context;
using SixConsultApi.Infra.Data.Repository.interfaces;
using System;
using System.Linq;

namespace SixConsultApi.Infra.Data.Repository
{
    public class ProfileRepository : BaseRepository<Domain.Entities.Profile>, IProfileRepository
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public ProfileRepository(ContextDB context, IMapper mapper, IOptions<AppSettings> appSettings) : base(context: context, mapper)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
        }

        override
        public Domain.Entities.Profile GetById(long id)
        {
            return _context.Profile.AsQueryable().Where(x => x.Id == id).FirstOrDefault();
        }

        override
        public IQueryable<Domain.Entities.Profile> Query(string filter){
            var query = _context.Profile.AsQueryable();

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
