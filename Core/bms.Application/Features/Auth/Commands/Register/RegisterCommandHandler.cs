using AutoMapper;
using bms.Application.Features.Auth.Rules;
using bms.Application.Services.AuthServices;
using bms.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;
        private readonly IAuthService authService;

        public RegisterCommandHandler(IMapper mapper, UserManager<User> userManager, AuthRules authRules, IAuthService authService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.authRules = authRules;
            this.authService = authService;
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {

            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User>(request);
            await authService.Register(user, request.Password, request.Email);
            
            return Unit.Value;
        }
    }
}
