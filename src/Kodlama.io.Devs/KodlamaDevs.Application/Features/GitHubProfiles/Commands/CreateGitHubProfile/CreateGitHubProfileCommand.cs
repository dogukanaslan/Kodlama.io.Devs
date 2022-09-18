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

namespace KodlamaDevs.Application.Features.GitHubProfiles.Commands.CreateGitHubProfile
{
    public class CreateGitHubProfileCommand:IRequest<CreatedGitHubProfileDto>
    {
        public int MemberId { get; set; }
        public string ProfileURL { get; set; }

        public class CreatedGitHubProfileCommandHandler : IRequestHandler<CreateGitHubProfileCommand, CreatedGitHubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly GitHubProfileBusinessRules _gitHubProfileBusinessRules;

            public CreatedGitHubProfileCommandHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository, GitHubProfileBusinessRules gitHubProfileBusinessRules)
            {
                _mapper = mapper;
                _gitHubProfileRepository = gitHubProfileRepository;
                _gitHubProfileBusinessRules = gitHubProfileBusinessRules;
            }

            public async Task<CreatedGitHubProfileDto> Handle(CreateGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                await _gitHubProfileBusinessRules.GitHubProfileURLCanNotBeDuplicatedWhenInsertedOrUpdated(request.ProfileURL);

                GitHubProfile gitHubProfile = _mapper.Map<GitHubProfile>(request);
                GitHubProfile mappedGitHubProfile = await _gitHubProfileRepository.AddAsync(gitHubProfile);
                CreatedGitHubProfileDto createdGitHubProfileDto = _mapper.Map<CreatedGitHubProfileDto>(mappedGitHubProfile);
                return createdGitHubProfileDto;
            }
        }
    }
}
