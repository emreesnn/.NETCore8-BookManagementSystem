using bms.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Auth.Rules
{
    public class AuthRules()
    {
        public Task EmailOrPasswordMustBeValid(User user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new BadRequestException("Email veya Şifre hatalı!");
            return Task.CompletedTask;
        }

        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new BadRequestException("Böyle bir kullanıcı zaten var!");
            return Task.CompletedTask;
        }

    }
}
