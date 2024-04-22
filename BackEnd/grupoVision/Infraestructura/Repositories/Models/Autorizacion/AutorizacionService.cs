
using Core.Dto;
using Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infraestructura.Repositories.Models.Autorizacion
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly IConfiguration _configuration;

        public AutorizacionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GenerarToken(string idUsuario)
        {
            var key = "=testjwt5612012343r33ewwefwefwefwefwewefwew";
            var keyBytes = Encoding.ASCII.GetBytes(key);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUsuario));

            var credencialesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = credencialesToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return tokenCreado;


        }

        private string GenerarRefreshToken()
        {

            var byteArray = new byte[64];
            var refreshToken = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(byteArray);
                refreshToken = Convert.ToBase64String(byteArray);
            }
            return refreshToken;
        }


        public AutorizacionResponse DevolverToken(AutorizacionRequest autorizacion,string id)
        {
            string tokenCreado = GenerarToken(id);

            string refreshTokenCreado = GenerarRefreshToken();

            return new AutorizacionResponse() { Token = tokenCreado, Resultado = true, RefreshToken = refreshTokenCreado, Msg = "Ok" };
        }
    }
}
