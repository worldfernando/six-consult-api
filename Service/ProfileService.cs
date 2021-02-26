using AutoMapper;
using SixConsultApi.Infra.Data.Context;
using SixConsultApi.Domain.Entities;
using System.Linq;
using SixConsultApi.Service.Interfaces;
using SixConsultApi.Infra.Data.Repository.interfaces;

namespace SixConsultApi.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly IProfileRepository _ProfileRepository;

        public ProfileService(IProfileRepository ProfileRepository, IMapper mapper)
        {
            this._ProfileRepository = ProfileRepository;
            this._mapper = mapper;
        }
        public Domain.Entities.Profile Delete(Domain.Entities.Profile objectInstance)
        {
            return _ProfileRepository.Delete(objectInstance);
        }

        public Domain.Entities.Profile GetById(int id)
        {
            return _ProfileRepository.GetById(id);
        }

        public Domain.Entities.Profile Post(Domain.Entities.Profile objectInstance)
        {
            return _ProfileRepository.Post(objectInstance);
        }

    public IQueryable<Domain.Entities.Profile> Query(string filter)
    {
      return _ProfileRepository.Query(filter);
    }

    public Domain.Entities.Profile Update(Domain.Entities.Profile objectInstance)
        {
            return _ProfileRepository.Update(objectInstance);
        }
    }
}
