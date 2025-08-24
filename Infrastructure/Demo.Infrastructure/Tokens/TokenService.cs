using Demo.Application.Interfaces.Tokens;
using Demo.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> userManager;
        private readonly TokenSettings tokenSettings;
        public TokenService(IOptions<TokenSettings> options, UserManager<User> userManager)
        {
            this.userManager = userManager;
            tokenSettings = options.Value;
        }
        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            var Claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
            };
            foreach (var role in roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));

            var token = new JwtSecurityToken(
                issuer: tokenSettings.Issuer,
                audience: tokenSettings.Audince,
                expires: DateTime.Now.AddMinutes(tokenSettings.TokenValidityInMunistes),
                claims: Claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            await userManager.AddClaimsAsync(user, Claims);
            return token;
        }
        public string GenerateRefreshToken()
        {
            var randonNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randonNumber);
            return Convert.ToBase64String(randonNumber);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            TokenValidationParameters tokenValidationParamaters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret)),
                ValidateLifetime = false,
            };
            JwtSecurityTokenHandler tokenHandler = new();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParamaters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken
                || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Token Bulunamadı");
            }
            return principal;

        }
    }
}
