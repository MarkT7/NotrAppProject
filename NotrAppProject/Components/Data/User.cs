using FluentValidation;

namespace NotrAppProject.Components.Data
{
    public class User
    {
        public int Id { get; set; }
        public String email { get; set; }
        public String username { get; set; }
        public string password { get; set; }

    }

    public class UserValidatorRegister : AbstractValidator<User>
    {
        public UserValidatorRegister() 
        {
            RuleFor(x => x.email).EmailAddress().NotEmpty();
            RuleFor(x => x.username).MaximumLength(15).MinimumLength(4).NotEmpty();
            RuleFor(x => x.password).MaximumLength(15).MinimumLength(4).NotEmpty();
        }
    }

    public class UserValidatorLogIn : AbstractValidator<User>
    {
        public UserValidatorLogIn()
        {
            RuleFor(x => x.username).MaximumLength(15).MinimumLength(4).NotEmpty();
            RuleFor(x => x.password).MaximumLength(15).MinimumLength(4).NotEmpty();
        }
    }
}
