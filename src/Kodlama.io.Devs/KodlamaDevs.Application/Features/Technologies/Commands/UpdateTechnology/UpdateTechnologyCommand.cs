using AutoMapper;
using KodlamaDevs.Application.Features.Technologies.Dtos;
using KodlamaDevs.Application.Features.Technologies.Rules;
using KodlamaDevs.Application.Services.Repositories;
using KodlamaDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class UpdatedTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdatedTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {

                await _technologyBusinessRules.TechnologyShouldExistWhenUpdated(request.Id, request.Name);
                await _technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInsertedOrUpdated(request.Name);

                Technology? technology = await _technologyRepository.GetAsync(p => p.Id == request.Id);
                Technology updatedTechnology = await _technologyRepository.UpdateAsync(_mapper.Map(request, technology));
                UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);
                return updatedTechnologyDto;
            }
        }
    }
}
