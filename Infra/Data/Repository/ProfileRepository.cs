using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Helpers;
using SixConsultApi.Infra.Data.Context;
using SixConsultApi.Infra.Data.Repository.interfaces;
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
        public Domain.Entities.Profile GetById(int id)
        {
            return _context.Profile.AsQueryable().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
