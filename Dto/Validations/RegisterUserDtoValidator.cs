using FluentValidation;
using SixConsultApi.Dto.User;

namespace SixConsultApi.Dto.Validations
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
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

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Senha não informada");
        }
    }
}
