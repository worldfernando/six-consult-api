
using System;

namespace SixConsultApi.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; }
        public long ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public User(string name, string email, string password, long profileId)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.ProfileId = profileId;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        public User(long id, string name, string email, string password, long profileId)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.ProfileId = profileId;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}