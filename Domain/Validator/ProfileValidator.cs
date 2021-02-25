
using FluentValidation;
using SixConsultApi.Domain.Entities;

namespace SixConsultApi.Domain.Notification
{
    public class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O Nome não pode ser vazio")
                .Length(0, 60)
                .WithMessage("O Nome não pode conter mais de 60 caracteres");
        }
    }
}