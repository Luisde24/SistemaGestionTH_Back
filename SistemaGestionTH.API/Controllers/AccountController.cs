using Microsoft.AspNetCore.Mvc;
using SistemaGestionTH.API.Validation;
using SistemaGestionTH.Application.EntitiesDtos;
using SistemaGestionTH.Domain.Interfaces;

namespace SistemaGestionTH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticate _auth;
        public AccountController(IAuthenticate auth)
        {
            _auth = auth;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginDto>> Login(LoginDto loginDto)
        {
            if(AccountValidation.validateLogin(loginDto))
                return BadRequest($"Error al diligenciar el usuario o clave");

            var result = await _auth.Authentication(loginDto.Email, loginDto.Password);

            if (!result)
                return BadRequest("Credenciales Invalidas");

            return Ok("Ingreso exitoso");
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<RegisterDto>> Register(RegisterDto registerDto)
        {
            if (AccountValidation.validateRegister(registerDto))
                return BadRequest($"Error al diligenciar al registrar el usuario");

            var result = await _auth.RegisterUser(registerDto.Email, registerDto.Password);

            if (!result)
                return BadRequest("Credenciales Invalidas");

            return Ok("Usuario creado de amnera existosa");

        }
    }
}
