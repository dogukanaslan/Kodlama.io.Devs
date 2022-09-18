using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Domain.Entities
{
    public class Member:User
    {
        public virtual ICollection<GitHubProfile> GitHubProfiles { get; set; }
        public Member()
        {
        }

        public Member(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status, AuthenticatorType authenticatorType) : base(id, firstName, lastName, email, passwordSalt, passwordHash, status, authenticatorType)
        {
        }
    }
}
