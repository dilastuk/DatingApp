using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key; //LA chiave usata per firmare

        //nell'inizializzazione richiamo e ?? TokenKey
        public TokenService(IConfiguration config){
            _key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public string CreateToken(AppUser user)
        {
            //Piazzo i claim: in questo caso solo useriD => NameID
            var claims=new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
            };
            //Creo le credenziali per firmare
            var creds=new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);

            //Faccio il SecurityTokendDescriptor: Ci piazzo i Claim, QUando Scade, e gli passo le credenziali
            var tokenDescriptor= new SecurityTokenDescriptor{
                Subject=new ClaimsIdentity(claims),
                Expires= System.DateTime.Now.AddDays(7),
                SigningCredentials = creds

            };

            //Creo il token:
            var TokenHandler=new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(tokenDescriptor);

            return TokenHandler.WriteToken(token);

        }
    }
}