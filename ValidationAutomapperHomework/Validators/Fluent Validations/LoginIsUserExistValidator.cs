using FluentValidation;
using ValidationAutomapperHomework.Models;
using ValidationAutomapperHomework.Validators.Data_Annotations;
using ValidationAutomapperHomework.View_Models;

namespace ValidationAutomapperHomework.Validators.Fluent_Validations
{
    public class LoginIsUserExistValidator:AbstractValidator<LoginViewModel>
    {
        private readonly UsersDBContext _context;
        public LoginIsUserExistValidator(UsersDBContext context)
        {
            _context=context;

            RuleFor(l => l.Username)
                .Must(BeUsernameExist!)
                .WithMessage("Username or password doesn`t exist or correct");

            

        }

        private bool BeUsernameExist(string username)
        {
            return _context._users.Any(u => u.Usernaame == username);
        }

    }
}
