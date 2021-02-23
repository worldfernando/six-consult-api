using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Dto.User
{
    public class UserLoggedDto: Dto
    {        
        public string Name { get; }
        public string Email { get; }
        public string Token { get; }

        public UserLoggedDto(string Name, string Email, string Token)
        {
            this.Name = Name;
            this.Email = Email;
            this.Token = Token;
        }
    }
}
