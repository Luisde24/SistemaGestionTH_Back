using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaGestionTH.API.AuthenticationJWT;
using SistemaGestionTH.API.Validation;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaGestionTH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _auth;
        private readonly IConfiguration _config;
        public TokenController(IAuthenticate authentication, IConfiguration configuration)
        {
            _auth = authentication ?? throw new ArgumentNullException(nameof(authentication));
            _config = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<UserToken>> Login(LoginDto userInfo)
        {
            if (AccountValidation.validateLogin(userInfo))
                return BadRequest($"Error al diligenciar el usuario o clave");

            var result = await _auth.Authentication(userInfo.Email, userInfo.Password);

            if (!result)
                return BadRequest("Usuario con credenciales incorrecta");

                return GenerateToken(userInfo);

        }

        private UserToken GenerateToken(LoginDto userInfo)
        {
            //declaraciones del usuario
            var claimsToken = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //usar clave privada para generar el token
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //Definir expiracion token
            var expiration = DateTime.UtcNow.AddHours(1);


            JwtSecurityToken token = new JwtSecurityToken(
                
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claimsToken,
                expires: expiration,
                signingCredentials: credentials
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
