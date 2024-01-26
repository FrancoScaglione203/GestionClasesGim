using GestionClasesGim.DTOs;
using GestionClasesGim.Helpers;
using GestionClasesGim.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionClasesGim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        /// <summary>
        /// Login con Dni y clave de Usuario
        /// </summary>
        /// <param name="dto"></param> 
        /// <returns>Retorna 200 si se loguea o 401 si algun dato es incorrecto</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var usuarioCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);
            if (usuarioCredentials is null) return Unauthorized("Datos incorrectos");

            var token = _tokenJwtHelper.GenerateToken(usuarioCredentials);

            var usuario = new UsuarioLoginDto()
            {
                Id = usuarioCredentials.Id,
                RoleId = usuarioCredentials.RoleId,
                Dni = usuarioCredentials.Dni, 
                Token = token
            };


            return Ok(usuario);

        }
    }
}