using Demo.Application.Bases;

namespace Demo.Application.Features.Auth.Exceptions
{
    public class EmailAdressShuldBeValidException : BaseException
    {
        public EmailAdressShuldBeValidException() : base("Böyle Bir Email Adresi Bulunmamaktadır")
        {

        }
    }
}
