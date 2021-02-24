using FluentValidation;
using SixConsultApi.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Dto.Validations
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {
            RuleFor(a => a.FTIN)
                .NotEmpty()
                .WithMessage("O Cnpj não pode ser vazio")
                .Length(14, 14)
                .WithMessage("Cnpj deve possuir 14 números");

            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("A Razão Social não pode ser vazio")
                .Length(0, 60)
                .WithMessage("A Razão Social não pode conter mais de 60 caracteres");

            RuleFor(a => a.TradeName)
                .NotEmpty()
                .WithMessage("O Nome Fantasia não pode ser vazio")
                .Length(0, 60)
                .WithMessage("O Nome Fantasia não pode conter mais de 60 caracteres");

            RuleFor(a => a.ContactEmail)
                .NotEmpty()
                .WithMessage("O Email de contato não pode ser vazio")
                .EmailAddress()
                .WithMessage("Email de contato é inválido")
                .Length(0, 50)
                .WithMessage("O Email de contato não pode conter mais de 50 caracteres");

            RuleFor(a => a.ContactPhone)
                .NotEmpty()
                .WithMessage("O Telefone de contato não pode ser vazio");
        }
    }
}
