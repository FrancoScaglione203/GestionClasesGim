using GestionClasesGim.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionClasesGim.Helpers
{
    public class TokenJwtHelper
    {
        private IConfiguration _configuration; //Permite traer la key de appsettings atraves de inyeccion del program.cs
        public TokenJwtHelper(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        /// <summary>
        /// Genera un token JWT basado en la informacion del usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>El token JWT generado como una cadena.</returns>
        public string GenerateToken(Usuario usuario) 
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),  //trae el subject del appsttings
                new Claim("Dni",usuario.Dni.ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, usuario.RoleId.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //algoritmo el cual se usa para encriptar la informacion

            var securityToken = new JwtSecurityToken(  //GENERACION DE TOKEN
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),  //Tiempo de duracion del Token
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
    }
}
