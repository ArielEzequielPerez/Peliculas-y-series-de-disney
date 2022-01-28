using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PeliculasSeries.Services.Interface;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace PeliculasSeries.Service
{
    public class TokenService : ITokenServices
    {
        private readonly SymmetricSecurityKey _ssKey;
        public TokenService(IConfiguration configuration)
        {
            _ssKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["KeyToken"]));
        }
        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                  new Claim(JwtRegisteredClaimNames.NameId, user.Name)             
            };
             var credentials = new SigningCredentials(_ssKey, SecurityAlgorithms.HmacSha512Signature);
             var TokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(claims),
                 Expires = System.DateTime.Now.AddDays(1),
                 SigningCredentials = credentials
             };

             var TokenHandler = new JwtSecurityTokenHandler();
             var Token = TokenHandler.CreateToken(TokenDescriptor);

                return TokenHandler.WriteToken(Token);
        }
    }
}