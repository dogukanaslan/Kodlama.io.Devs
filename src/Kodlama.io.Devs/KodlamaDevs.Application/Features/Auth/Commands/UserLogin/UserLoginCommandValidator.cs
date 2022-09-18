using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.Auth.Commands.UserLogin
{
    public class UserLoginCommandValidator:AbstractValidator<UserLoginComand>
    {
        public UserLoginCommandValidator()
        {
            RuleFor(x=>x.Email).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
            RuleFor(x => x.AuthenticatorCode).NotEmpty();
        }
    }
}
