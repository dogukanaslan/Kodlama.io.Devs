using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQueryValidator:AbstractValidator<GetByIdProgrammingLanguageQuery>
    {
        public GetByIdProgrammingLanguageQueryValidator()
        {
            //RuleFor(p => p.Id).NotEmpty();
        }
    }
}
