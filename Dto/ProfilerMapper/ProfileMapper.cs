using AutoMapper;
using SixConsultApi.Dto.Customer;
using SixConsultApi.Dto.User;

namespace SixConsultApi.Dto.ProfilerMapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<SixConsultApi.Domain.Entities.User, UserDto>();
            CreateMap<SixConsultApi.Domain.Entities.User, UserLoggedDto>();
            CreateMap<SixConsultApi.Domain.Entities.Customer, CustomerDto>();
        }
    }
}
