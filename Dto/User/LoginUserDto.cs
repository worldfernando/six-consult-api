using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Dto.User
{
    public class LoginUserDto
    {
        public string Email { get; }
        public string Password { get; }

        public LoginUserDto(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
    }
}
