﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Dto.User
{
    public class RegisterUserDto
    {
        public string Name { get; }
        public string Email { get; }
        public string Password { get; set; }
        public long ProfileId { get; set; }

        public RegisterUserDto(string Name, string Email, string Password, long profileId)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.ProfileId = profileId;
        }
    }
}
