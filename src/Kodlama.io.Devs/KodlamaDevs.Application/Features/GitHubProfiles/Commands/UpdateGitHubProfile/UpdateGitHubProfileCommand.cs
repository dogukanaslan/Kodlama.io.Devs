using AutoMapper;
using KodlamaDevs.Application.Features.GitHubProfiles.Dtos;
using KodlamaDevs.Application.Features.GitHubProfiles.Rules;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Rules;
using KodlamaDevs.Application.Services.Repositories;
using KodlamaDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile
{
    public class UpdateGitHubProfileCommand:IRequest<UpdatedGitHubProfileDto>
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string? ProfileURL { get; set; }

        public class UpdatedGitHubProfileCommandHandler : IRequestHandler<UpdateGitHubProfileCommand, UpdatedGitHubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly GitHubProfileBusinessRules _gitHubProfileBusinessRules;

            public UpdatedGitHubProfileCommandHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository, GitHubProfileBusinessRules gitHubProfileBusinessRules)
            {
                _mapper = mapper;
                _gitHubProfileRepository = gitHubProfileRepository;
                _gitHubProfileBusinessRules = gitHubProfileBusinessRules;
            }

            public async Task<UpdatedGitHubProfileDto> Handle(UpdateGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                await _gitHubProfileBusinessRules.GitHubProfileURLCanNotBeDuplicatedWhenInsertedOrUpdated(request.ProfileURL);

                GitHubProfile? gitHubProfile = await _gitHubProfileRepository.GetAsync(x => x.Id == request.Id);
                GitHubProfile updatedGitHubProfile = await _gitHubProfileRepository.UpdateAsync(gitHubProfile);
                UpdatedGitHubProfileDto updatedGitHubProfileDto = _mapper.Map<UpdatedGitHubProfileDto>(updatedGitHubProfile);
                return updatedGitHubProfileDto;
            }
        }
    }
}
