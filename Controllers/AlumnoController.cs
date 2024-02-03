using GestionClasesGim.DTOs;
using GestionClasesGim.Entities;
using GestionClasesGim.Infraestructure;
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAll()
        {
            var alumnos = await _unitOfWork.AlumnoRepository.GetAll();

            return alumnos;
        }



        /// <summary>
        /// Agrega un Alumno a la DB
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Ok(200) si se agrego bien o Error si hubo un error</returns>
        [HttpPost]
        [Authorize]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AlumnoDto dto)
        {
            if (await _unitOfWork.UsuarioRepository.UsuarioEx(dto.Dni)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el dni {dto.Dni}");
            var alumno = new Alumno(dto);

            await _unitOfWork.AlumnoRepository.Insert(alumno);
            await _unitOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "Alumno registrado con éxito!");
        }
    }
}
