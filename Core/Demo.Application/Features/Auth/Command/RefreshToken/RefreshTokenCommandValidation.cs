using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandValidation : AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenCommandValidation()
        {
            RuleFor(x => x.AccessToken).NotEmpty();

            RuleFor(x => x.RefreshToken).NotEmpty();
        }

    }
}
