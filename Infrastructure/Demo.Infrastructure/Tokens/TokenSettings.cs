using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Tokens
{
    public class TokenSettings
    {
        public string Audince { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int TokenValidityInMunistes { get; set; }
        public int RefreshTokenValidityInDays { get; set; }
    }
}
