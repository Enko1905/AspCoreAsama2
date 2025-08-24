using Demo.Application.Bases;
using Demo.Application.Features.Auth.Exceptions;
using Demo.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null)
            {
                throw new UserAlreadyExistException();
            }
            return Task.CompletedTask;

        }
        public Task EmailOrPasswordShouldNotBeInvalid(User ? user, bool checkPassword)
        {
            if(user is null || !checkPassword)
            {
                throw new EmailOrPasswordShouldBeInvalidException();
            }
            return Task.CompletedTask;

        }
        public Task RefreshTokenShouldNotBeExpires(DateTime? expiryDate)
        {
            if (expiryDate <= DateTime.UtcNow)
            {
                throw new RefreshTokenShouldNotBeExpiresException();
            }
            return Task.CompletedTask;

        }
        public Task EmailAdressShuldBeValid(User? user)
        {
            if (user is null)
            {
                throw new EmailAdressShuldBeValidException();
            }
            return Task.CompletedTask;

        }
    }
}
