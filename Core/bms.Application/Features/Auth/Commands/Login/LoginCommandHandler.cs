using bms.Application.Services.AuthServices;
using bms.Application.Services.TokenServices;
using bms.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IAuthService authService;

        public LoginCommandHandler(IAuthService authService, TokenManager tokenManager)
        {
            this.authService = authService;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await authService.GetUserIfValid(request.Email, request.Password);
            (string token, DateTime expiration) = await authService.CreateToken(user);
            string refreshToken = authService.CreateRefreshToken(user);

            return new()
            {
                Token = token,
                Expiration = expiration
            };
        }
    }
}
