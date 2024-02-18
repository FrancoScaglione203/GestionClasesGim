using GestionClasesGim.DTOs;
using GestionClasesGim.Entities;
using GestionClasesGim.Infraestructure;
using GestionClasesGim.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace GestionClasesGim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los usuarios
        /// </summary>
        /// <returns>Retorna lista de clase Usuario</returns>
        //[Authorize(Policy = "AdminConsultor")]
        [HttpGet]
        [Route("Clases")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Clase>>> GetAll()
        {
            var clases = await _unitOfWork.ClaseRepository.GetAll();

            return clases;
        }

        /// <summary>
        /// Devuelve todos las clases
        /// </summary>
        /// <returns>Retorna lista de clase Alumno</returns>
        //[Authorize(Policy = "AdminConsultor")]
        [HttpGet]
        [Route("ClasesxAlumno")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Clase>>> GetClasesByIdAlumno([FromQuery] int idAlumno)
        {
            var clases = await _unitOfWork.ClaseRepository.GetAllByIdAlumno(idAlumno);

            return clases;
        }

        /// <summary>
        /// Agrega un Usuario a la DB
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Ok(200) si se agrego bien o Error si hubo un error</returns>
        [HttpPost]
        [Authorize]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(ClaseDto dto)
        {
            //if (await _unitOfWork.UsuarioRepository.UsuarioEx(dto.Dni)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el dni {dto.Dni}");
            var clase = new Clase(dto);

            await _unitOfWork.ClaseRepository.Insert(clase);
            await _unitOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "Clase registrada con éxito!");
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
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] ClaseDto dto)
        {

            var result = await _unitOfWork.ClaseRepository.Update(new Clase(dto, id));
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el usuario");
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
            var result = await _unitOfWork.ClaseRepository.DeleteLogico(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar la clase");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }

        }

        /// <summary>
        /// Actualiza el servicio seleccionado por id por el UsuarioDto que se envia
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 si ingresaron id invalido</returns>
        //[Authorize(Policy = "Admin")]
        [Authorize]
        [HttpPut("Inscripcion")]
        public async Task<IActionResult> Inscripcion([FromQuery] int idClase, [FromQuery] int idAlumno)
        {

            //VALIDACION SI LA CLASE TIENE CUPOS

            var result = await _unitOfWork.ClaseRepository.Inscripcion(idClase, idAlumno);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }

        }


        /// <summary>
        /// Actualiza el servicio seleccionado por id por el UsuarioDto que se envia
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 si ingresaron id invalido</returns>
        //[Authorize(Policy = "Admin")]
        [Authorize]
        [HttpPut("Cancelacion")]
        public async Task<IActionResult> Cancelacion([FromQuery] int idClase, [FromQuery] int idAlumno)
        {

            //VALIDACION SI LA CLASE TIENE CUPOS

            var result = await _unitOfWork.ClaseRepository.Cancelacion(idClase, idAlumno);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }

        }

    }
}
