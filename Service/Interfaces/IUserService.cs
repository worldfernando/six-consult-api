using SixConsultApi.Dto.User;

namespace SixConsultApi.Service.Interfaces
{
    interface IUserService
    {
        UserLoggedDto Login(LoginUserDto loginUserDto);
        UserDto Register(RegisterUserDto registerUserDto);
    }
}
