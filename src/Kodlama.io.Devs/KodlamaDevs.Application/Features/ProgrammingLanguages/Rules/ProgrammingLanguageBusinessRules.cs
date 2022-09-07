using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaDevs.Application.Services.Repositories;
using KodlamaDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Language Name Already Exists.");
        }

        public async Task ProgrammingLanguageShouldExistWhenRequested(int id)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == id);
            if (programmingLanguage == null) throw new BusinessException("Requested Programming Language Doesnt Exist");
        }

        public async Task ProgrammingLanguageShouldExistWhenUpdated(int id, string name)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == id);
            if (programmingLanguage == null)
            { 
                throw new BusinessException("Requested Programming Language Doesnt Exist");
            }
            else
            {
                programmingLanguage.Name = name;
            }
        }
    }
}
