using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using KodlamaDevs.Application.Features.Auth.Rules;
using KodlamaDevs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.Auth.Commands.UserLogin
{
    public class UserLoginComand :UserForLoginDto, IRequest<AccessToken>
    {
        public class UserLoginCommandHandler : IRequestHandler<UserLoginComand, AccessToken>
        {
            private readonly IMapper _mapper;
            private readonly IMemberRepository _memberRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly ITokenHelper _tokenHelper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public UserLoginCommandHandler(IMapper mapper, IMemberRepository memberRepository, AuthBusinessRules authBusinessRules, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _mapper = mapper;
                _memberRepository = memberRepository;
                _authBusinessRules = authBusinessRules;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(UserLoginComand request, CancellationToken cancellationToken)
            {
                var user = await _memberRepository.GetAsync(u => u.Email.ToLower() == request.Email.ToLower());

                await _authBusinessRules.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

                var claims = await _userOperationClaimRepository.GetListAsync(
                                                                             c => c.Id == user.Id,
                                                                             include: m => m.Include(z => z.OperationClaim),
                                                                             cancellationToken:cancellationToken
                                                                             );
                var accesToken = _tokenHelper.CreateToken(user, claims.Items.Select(x=>x.OperationClaim).ToList());
                return accesToken;
            }
        }
    }
}
