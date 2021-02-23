using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Dto.User
{
    public class UserDto: Dto
    {        
        public string Name { get; }
        public string Email { get; }

        public UserDto(string Name, string Email)
        {
            this.Name = Name;
            this.Email = Email;
        }
    }
}
