using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaDevs.Application.Services.Repositories;
using KodlamaDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Technology Name Already Exists.");
        }

        public async Task TechnologyShouldExistWhenRequested(int id)
        {
            Technology? technology = await _technologyRepository.GetAsync(p => p.Id == id);
            if (technology == null) throw new BusinessException("Requested Technology Doesnt Exist");
        }

        public async Task TechnologyShouldExistWhenUpdated(int id, string name)
        {
            Technology? technology = await _technologyRepository.GetAsync(p => p.Id == id);
            if (technology == null)
            {
                throw new BusinessException("Requested Technology Doesnt Exist");
            }
            else
            {
                technology.Name = name;
            }
        }

    }
}
