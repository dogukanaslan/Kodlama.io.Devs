using Core.Persistence.Repositories;
using KodlamaDevs.Application.Services.Repositories;
using KodlamaDevs.Domain.Entities;
using KodlamaDevs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Persistence.Repositories
{
    public class MemberRepository : EfRepositoryBase<Member, BaseDbContext>, IMemberRepository
    {
        public MemberRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
