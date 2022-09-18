using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Domain.Entities
{
    public class GitHubProfile:Entity
    {
        public string ProfileURL { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        public GitHubProfile()
        {
        }

        public GitHubProfile(int id, string profileURL, int memberId, Member member)
        {
            Id = id;
            ProfileURL = profileURL;
            MemberId = memberId;
            Member = member;
        }
    }
}
