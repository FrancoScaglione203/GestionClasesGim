using GestionClasesGim.Entities;
using GestionClasesGim.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionClasesGim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los usuarios
        /// </summary>
        /// <returns>Retorna lista de clase Usuario</returns>
        //[Authorize(Policy = "AdminConsultor")]
        [HttpGet]
        [Route("Usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            return usuarios;
        }
    }
}
