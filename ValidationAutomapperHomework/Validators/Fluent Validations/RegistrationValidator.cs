using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using ValidationAutomapperHomework.Models;
using ValidationAutomapperHomework.View_Models;

namespace ValidationAutomapperHomework.Validators.Fluent_Validations
{
    public class RegistrationValidator : AbstractValidator<RegistrationViewModel>
    {
        private readonly UsersDBContext _context;
        public RegistrationValidator(UsersDBContext context)
        {
            _context = context;
            RuleFor(x => x.Usernaame)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(10)
                .Must(BeUniqueUsername)
                .WithMessage("Account with this username already exists");


            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(BeUniqueEmail)
                .WithMessage("Account with this email is already exists");

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches("^(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{5,16}$")
               .WithMessage("Password must be 5-16 characters long and contain at least one uppercase letter and one digit.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("Confirm password must equal to password")
                .Matches("^(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{5,16}$")
                .WithMessage("Confirm password must contain at leat 1 upper lower and numberic character");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Phone number is not correct - example:+994501234567");

            RuleFor(x => x.Address)
                .MaximumLength(30)
                .MinimumLength(6);

            RuleFor(x => x.City)
                .MaximumLength(26)
                .MinimumLength(3);

            RuleFor(x => x.Region)
                .MaximumLength(26)
                .MinimumLength(3);

        }
        private bool BeUniqueUsername(string username)
        {
            return !_context._users.Any(u => u.Usernaame == username);
        }
        private bool BeUniqueEmail(string email)
        {
            return !_context._users.Any(u => u.Email == email);
        }
    }
}
