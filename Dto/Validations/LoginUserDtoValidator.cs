using FluentValidation;
using SixConsultApi.Dto.User;

namespace SixConsultApi.Dto.Validations
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(x => x.email)
                .NotEmpty()
                .WithMessage("Email não informado");

            RuleFor(x => x.password)
                .NotEmpty()
                .WithMessage("Senha não informada");
        }
    }
}
