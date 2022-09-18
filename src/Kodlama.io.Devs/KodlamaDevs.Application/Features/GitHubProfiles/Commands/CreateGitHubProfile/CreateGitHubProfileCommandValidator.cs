using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.GitHubProfiles.Commands.CreateGitHubProfile
{
    public class CreateGitHubProfileCommandValidator:AbstractValidator<CreateGitHubProfileCommand>
    {
        public CreateGitHubProfileCommandValidator()
        {
            RuleFor(p=>p.MemberId).NotEmpty();
            RuleFor(p => p.ProfileURL).NotEmpty();
        }
    }
}
