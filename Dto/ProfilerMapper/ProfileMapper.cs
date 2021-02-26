using AutoMapper;
using SixConsultApi.Dto.Customer;
using SixConsultApi.Dto.Profile;
using SixConsultApi.Dto.User;

namespace SixConsultApi.Dto.ProfilerMapper
{
    public class ProfileMapper : AutoMapper.Profile
    {
        public ProfileMapper()
        {
            CreateMap<SixConsultApi.Domain.Entities.User, UserDto>();
            CreateMap<SixConsultApi.Domain.Entities.User, UserLoggedDto>();
            CreateMap<SixConsultApi.Domain.Entities.Customer, CustomerDto>();
            CreateMap<SixConsultApi.Domain.Entities.Profile, ProfileDto>();
            CreateMap<SixConsultApi.Domain.Entities.Profile, BaseProfileDto>();

        }
    }
}
