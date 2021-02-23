
using System;

namespace SixConsultApi.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}