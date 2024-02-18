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
        /// Devuelve todos los alumnos
        /// </summary>
        /// <returns>Retorna lista de clase Alumno</returns>
        //[Authorize(Policy = "AdminConsultor")]
        [HttpGet]
        [Route("AlumnosxClase")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnosByIdClase([FromQuery] int idClase)
        {
            var alumnos = await _unitOfWork.AlumnoRepository.GetAllByIdClase(idClase);

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


        /// <summary>
        /// Actualiza el servicio seleccionado por id por el UsuarioDto que se envia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 si ingresaron id invalido</returns>
        //[Authorize(Policy = "Admin")]
        [Authorize]
        [HttpPut("Editar")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] AlumnoDto dto)
        {

            var result = await _unitOfWork.AlumnoRepository.Update(new Alumno(dto, id));
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el alumno");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }

        }


        /// <summary>
        /// Cambia a false el estado de la propiedad Activo del usuario seleccionado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se modifico con exito o 500 si hubo un error</returns>
        [Authorize]
        [HttpPut("DeleteLogico")]
        public async Task<IActionResult> DeleteLogico([FromQuery] int id)
        {
            var result = await _unitOfWork.AlumnoRepository.DeleteLogico(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el alumno");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }

        }
    }
}
