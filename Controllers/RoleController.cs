using GestionClasesGim.Entities;
using GestionClasesGim.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionClasesGim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los roles
        /// </summary>
        /// <returns>Retorna lista de roles</returns>
        [HttpGet]
        [Route("Roles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var Roles = await _unitOfWork.RoleRepository.GetAll();

            return Roles;
        }
    }
}
