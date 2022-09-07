using AutoMapper;
using Core.Persistence.Paging;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Models;
using KodlamaDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();
        }
    }
}
