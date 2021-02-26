using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixConsultApi.Dto.Profile;

namespace SixConsultApi.Dto.User
{
    public class UserDto: Dto
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public long ProfileId { get; set; }
        public BaseProfileDto Profile { get; set; }
        public UserDto(string Name, string Email)
        {
            this.Name = Name;
            this.Email = Email;
        }
    }
}
