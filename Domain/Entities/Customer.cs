
using System;

namespace SixConsultApi.Domain.Entities
{
    public class Customer : Entity
    {    
        public string FTIN { get; }
        public string Name { get; }
        public string TradeName { get; }
        public string ContactEmail { get; }
        public string ContactPhone { get; }

        public Customer(string FTIN, string Name, string TradeName, string ContactEmail, string ContactPhone)
        {
            this.FTIN = FTIN;
            this.Name = Name;
            this.TradeName = TradeName;
            this.ContactEmail = ContactEmail;
            this.ContactPhone = ContactPhone;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}