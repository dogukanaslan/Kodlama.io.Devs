using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile
{
    public class DeleteGitHubProfileCommandValidator:AbstractValidator<DeleteGitHubProfileCommand>
    {
        public DeleteGitHubProfileCommandValidator()
        {

        }
    }
}
