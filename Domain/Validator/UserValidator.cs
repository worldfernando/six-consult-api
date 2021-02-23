
using FluentValidation;
using SixConsultApi.Domain.Entities;

namespace SixConsultApi.Domain.Notification
{
  public class UserValidator : AbstractValidator<User>{
    public UserValidator()
    {
      RuleFor(a => a.Email)
        .NotEmpty()
        .WithMessage("O Email não pode ser vazio")
        .EmailAddress()
        .WithMessage("Email inválido")
        .Length(0, 50)
        .WithMessage("O Email não pode conter mais de 50 caracteres");

      RuleFor(a => a.Name)
        .NotEmpty()
        .WithMessage("O Nome não pode ser vazio")
        .Length(0, 60)
        .WithMessage("O Nome não pode conter mais de 60 caracteres");
    }
  }
}