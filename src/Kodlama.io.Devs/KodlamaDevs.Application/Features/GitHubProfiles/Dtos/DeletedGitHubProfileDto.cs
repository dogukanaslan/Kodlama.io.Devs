using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.GitHubProfiles.Dtos
{
    public class DeletedGitHubProfileDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string ProfileURL { get; set; }
    }
}
