using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile
{
    public class UpdateGitHubProfileCommandValidator:AbstractValidator<UpdateGitHubProfileCommand>
    {
        public UpdateGitHubProfileCommandValidator()
        {
            RuleFor(x=>x.ProfileURL).NotEmpty();
            RuleFor(x=>x.MemberId).NotEmpty();
        }
    }
}
