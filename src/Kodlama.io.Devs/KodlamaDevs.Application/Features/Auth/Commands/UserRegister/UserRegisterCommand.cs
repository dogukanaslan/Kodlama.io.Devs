using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaDevs.Application.Features.Auth.Rules;
using KodlamaDevs.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaDevs.Application.Services.Repositories;
using KodlamaDevs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaDevs.Application.Features.Auth.Commands.UserRegister
{
    public class UserRegisterCommand:UserForRegisterDto , IRequest<AccessToken>
    {
        public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, AccessToken>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public UserRegisterCommandHandler(IMemberRepository memberRepository, ITokenHelper tokenHelper, IMapper mapper, AuthBusinessRules authBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _memberRepository = memberRepository;
                _tokenHelper = tokenHelper;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.CheckIfUserExist(request.Email);

                HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

                var mappedUser = _mapper.Map<Member>(request);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;
                mappedUser.Status = true;

                var registeredUser = await _memberRepository.AddAsync(mappedUser);
                await _userOperationClaimRepository.AddAsync(new UserOperationClaim
                {
                    UserId = registeredUser.Id,
                    OperationClaimId = 2
                });

                var userClaims = await _userOperationClaimRepository.GetListAsync(x =>
                        x.UserId == registeredUser.Id,
                        include: x => x.Include(c => c.OperationClaim),
                        cancellationToken: cancellationToken);

                var accessToken = _tokenHelper.CreateToken(registeredUser, userClaims.Items.Select(x => x.OperationClaim).ToList());

                return accessToken;
            }
        }
    }
}
