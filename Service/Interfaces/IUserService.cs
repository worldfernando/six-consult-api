using SixConsultApi.Domain.Entities;
using SixConsultApi.Dto.User;

namespace SixConsultApi.Service.Interfaces
{
    public interface IUserService : IServiceCrud<User>
    {
        UserLoggedDto Login(LoginUserDto loginUserDto);
        UserDto Register(RegisterUserDto registerUserDto);
    }
}
