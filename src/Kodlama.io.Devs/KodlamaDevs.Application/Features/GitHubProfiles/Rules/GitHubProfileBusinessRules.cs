using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaDevs.Application.Services.Repositories;
using KodlamaDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.GitHubProfiles.Rules
{
    public class GitHubProfileBusinessRules
    {
        private readonly IGitHubProfileRepository _gitHubProfileRepository;

        public GitHubProfileBusinessRules(IGitHubProfileRepository gitHubProfileRepository)
        {
            _gitHubProfileRepository = gitHubProfileRepository;
        }

        public async Task GitHubProfileURLCanNotBeDuplicatedWhenInsertedOrUpdated(string profileURL)
        {
            IPaginate<GitHubProfile> result = await _gitHubProfileRepository.GetListAsync(p => p.ProfileURL == profileURL);
            if (result.Items.Any()) throw new BusinessException("GitHub Profile URL Already Exists.");
        }
    }
}
