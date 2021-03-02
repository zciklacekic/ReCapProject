using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.FirstName).MinimumLength(2);
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.LastName).MinimumLength(2);
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.PasswordHash).NotEmpty();
            RuleFor(p => p.PasswordSalt).NotEmpty();
            RuleFor(p => p.Status).NotEmpty();
        }
    }
}
