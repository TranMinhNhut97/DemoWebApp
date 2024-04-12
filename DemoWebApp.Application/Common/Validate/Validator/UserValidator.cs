using DemoWebApp.Application.Common.Entities;
using FluentValidation;

namespace DemoWebApp.Application.Common.Validate.Validator
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .WithMessage("User Name must not empty!");
            RuleFor(x => x.PassWord)
                .NotNull()
                .NotEmpty()
                .WithMessage("PassWord must not empty!");
        }
    }
}
