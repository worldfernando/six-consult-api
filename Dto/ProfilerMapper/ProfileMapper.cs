using AutoMapper;
using SixConsultApi.Dto.User;

namespace SixConsultApi.Dto.ProfilerMapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<SixConsultApi.Domain.Entities.Customer, UserDto>();
        }
    }
}
