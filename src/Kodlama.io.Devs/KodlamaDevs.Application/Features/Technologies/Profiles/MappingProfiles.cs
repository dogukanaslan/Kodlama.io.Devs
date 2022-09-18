using AutoMapper;
using Core.Persistence.Paging;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Models;
using KodlamaDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaDevs.Application.Features.Technologies.Commands.DeleteTechnology;
using KodlamaDevs.Application.Features.Technologies.Commands.UpdateTechnology;
using KodlamaDevs.Application.Features.Technologies.Dtos;
using KodlamaDevs.Application.Features.Technologies.Models;
using KodlamaDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();

            CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();

            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();

            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Technology, TechnologyListDto>().ForMember(c=>c.ProgrammingLanguageName, opt=>opt.MapFrom(c=>c.ProgrammingLanguage!.Name)).ReverseMap();

            //CreateMap<Technology, TechnologyGetByIdDto>().ReverseMap();
        }
    }
}
