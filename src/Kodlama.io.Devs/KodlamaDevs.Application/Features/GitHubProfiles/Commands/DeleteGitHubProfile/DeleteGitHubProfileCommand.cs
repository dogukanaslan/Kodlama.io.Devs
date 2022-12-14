using AutoMapper;
using KodlamaDevs.Application.Features.GitHubProfiles.Dtos;
using KodlamaDevs.Application.Features.GitHubProfiles.Rules;
using KodlamaDevs.Application.Services.Repositories;
using KodlamaDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile
{
    public class DeleteGitHubProfileCommand:IRequest<DeletedGitHubProfileDto>
    {
        public int Id { get; set; }

        public class DeletedGitHubProfileCommandHandler : IRequestHandler<DeleteGitHubProfileCommand, DeletedGitHubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly GitHubProfileBusinessRules _gitHubProfileBusinessRules;

            public DeletedGitHubProfileCommandHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository, GitHubProfileBusinessRules gitHubProfileBusinessRules)
            {
                _mapper = mapper;
                _gitHubProfileRepository = gitHubProfileRepository;
                _gitHubProfileBusinessRules = gitHubProfileBusinessRules;
            }

            public async Task<DeletedGitHubProfileDto> Handle(DeleteGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                GitHubProfile gitHubProfile = await _gitHubProfileRepository.GetAsync(g => g.Id == request.Id);
                GitHubProfile deletedGitHubProfile = await _gitHubProfileRepository.DeleteAsync(gitHubProfile);
                DeletedGitHubProfileDto deletedGitHubProfileDto = _mapper.Map<DeletedGitHubProfileDto>(deletedGitHubProfile);
                return deletedGitHubProfileDto;

            }
        }
    }
}
