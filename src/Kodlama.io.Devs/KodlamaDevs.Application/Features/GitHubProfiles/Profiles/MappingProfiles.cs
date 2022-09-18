using AutoMapper;
using KodlamaDevs.Application.Features.GitHubProfiles.Commands.CreateGitHubProfile;
using KodlamaDevs.Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile;
using KodlamaDevs.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile;
using KodlamaDevs.Application.Features.GitHubProfiles.Dtos;
using KodlamaDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaDevs.Application.Features.Technologies.Commands.DeleteTechnology;
using KodlamaDevs.Application.Features.Technologies.Dtos;
using KodlamaDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.GitHubProfiles.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GitHubProfile, CreatedGitHubProfileDto>().ReverseMap();
            CreateMap<GitHubProfile, CreateGitHubProfileCommand>().ReverseMap();

            CreateMap<GitHubProfile, DeletedGitHubProfileDto>().ReverseMap();
            CreateMap<GitHubProfile, DeleteGitHubProfileCommand>().ReverseMap();

            CreateMap<GitHubProfile, UpdatedGitHubProfileDto>().ReverseMap();
            CreateMap<GitHubProfile, UpdateGitHubProfileCommand>().ReverseMap();
        }

    }
}
