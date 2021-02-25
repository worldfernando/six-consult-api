
using System;

namespace SixConsultApi.Domain.Entities
{
    public class Customer : Entity
    {    
        public string FTIN { get; set; }
        public string Name { get; set; }
        public string TradeName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public long UserCreatedId { get; }
        public virtual User UserCreated { get; set; }
        public long UserUpdatedId { get; set; }
        public virtual User UserUpdated { get; set; }

        public Customer(string FTIN, string Name, string TradeName, string ContactEmail, string ContactPhone, long userCreatedId, long userUpdatedId)
        {
            this.FTIN = FTIN;
            this.Name = Name;
            this.TradeName = TradeName;
            this.ContactEmail = ContactEmail;
            this.ContactPhone = ContactPhone;
            this.UserCreatedId = userCreatedId;
            this.UserUpdatedId = userUpdatedId;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}