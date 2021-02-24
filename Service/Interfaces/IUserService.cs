using SixConsultApi.Dto.User;

namespace SixConsultApi.Service.Interfaces
{
    public interface IUserService
    {
        UserLoggedDto Login(LoginUserDto loginUserDto);
        UserDto Register(RegisterUserDto registerUserDto);
    }
}
