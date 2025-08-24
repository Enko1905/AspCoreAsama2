using Demo.Application.Bases;

namespace Demo.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldBeInvalidException() : base("Kullanıcı adı veya şifre hatalıdır")
        {
            
        }
    }
}
