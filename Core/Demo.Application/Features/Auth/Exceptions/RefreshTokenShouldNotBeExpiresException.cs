using Demo.Application.Bases;

namespace Demo.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiresException : BaseException
    {
        public RefreshTokenShouldNotBeExpiresException() : base("Oturum Süresi Dolmuştur")
        {

        }
    }
}
