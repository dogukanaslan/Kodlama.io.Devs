﻿using Core.Persistence.Repositories;
using KodlamaDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Services.Repositories
{
    public interface IMemberRepository:IAsyncRepository<Member>, IRepository<Member>
    {
    }
}
