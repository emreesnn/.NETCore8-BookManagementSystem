using bms.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Pipelines.Authorization
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, IAuthentication
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthorizationBehaviour(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var user = httpContextAccessor.HttpContext?.User;
           
            if (!user.IsInRole("user") || user == null)
            {
                throw new UnauthorizedAccessException("Bu işlem için ADMIN yetkisi gereklidir.");
            }

            TResponse response = await next();
            return response;
        }
    }
}


