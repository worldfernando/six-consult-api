using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Dto.Customer
{
    public class CustomerDto : Dto
    {
        public string FTIN { get; }
        public string Name { get; }
        public string TradeName { get; }
        public string ContactEmail { get; }
        public string ContactPhone { get; }

        public CustomerDto(long Id, string FTIN, string Name, string TradeName, string ContactEmail, string ContactPhone)
        {
            this.Id = Id;
            this.FTIN = FTIN;
            this.Name = Name;
            this.TradeName = TradeName;
            this.ContactEmail = ContactEmail;
            this.ContactPhone = ContactPhone;
        }
    }
}
