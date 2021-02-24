using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Dto.User
{
    public class UserLoggedDto : Dto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public UserLoggedDto(long id, string Name, string Email, string Token)
        {
            this.Id = id;
            this.Name = Name;
            this.Email = Email;
            this.Token = Token;
        }


    }
}
