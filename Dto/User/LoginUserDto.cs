using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Dto.User
{
    public class LoginUserDto
    {
        public string email { get; set; }
        public string password { get; set; }

        public LoginUserDto(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
