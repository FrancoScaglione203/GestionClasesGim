using GestionClasesGim.Entities;
using GestionClasesGim.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionClasesGim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AlumnoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los alumnos
        /// </summary>
        /// <returns>Retorna lista de clase Alumno</returns>
        //[Authorize(Policy = "AdminConsultor")]
        [HttpGet]
        [Route("Alumnos")]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAll()
        {
            var alumnos = await _unitOfWork.AlumnoRepository.GetAll();

            return alumnos;
        }
    }
}
