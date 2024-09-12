using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SpendWise.Domain.Entities;
using SpendWise.Domain.Security;

namespace SpendWise.Infrastructure.Security.Tokens
{
    public class AcessTokenGenerator : Domain.Security.IAcessTokenGenerator
    {
        private readonly uint _expirationTime;
        private readonly string _signingKey;
        public AcessTokenGenerator(uint expirationTime, string signingKey)
        {
            _expirationTime = expirationTime;
            _signingKey = signingKey;

        }

        public string Generate(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Sid, user.UserIdentify.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTime),
                SigningCredentials = new SigningCredentials(securityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity()
            };
            var tokenHendler = new JwtSecurityTokenHandler();
            var token = tokenHendler.CreateToken(tokenDescriptor);

            return tokenHendler.WriteToken(token);
        }

        private SymmetricSecurityKey securityKey()
        {
            var key = Encoding.UTF8.GetBytes(_signingKey);

            return new SymmetricSecurityKey(key);
        }
    }
}
