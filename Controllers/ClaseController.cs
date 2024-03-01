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
        /// Devuelve todoas las Clases
        /// </summary>
        /// <returns>Retorna lista del tipo Clase</returns>
        [HttpGet]
        [Route("Clases")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Clase>>> GetAll()
        {
            var clases = await _unitOfWork.ClaseRepository.GetAll();

            return clases;
        }


        /// <summary>
        /// Devuelve la Clase con el Id enviado por parametro 
        /// </summary>
        /// <returns>Retorna la Clase solicitada</returns>
        //[Authorize(Policy = "AdminConsultor")]
        [HttpGet]
        [Route("ClaseById")]
        [Authorize]
        public async Task<ActionResult<Clase>> GetById([FromQuery] int claseId)
        {
            var clase = await _unitOfWork.ClaseRepository.GetById(claseId);

            return clase;
        }


        /// <summary>
        /// devuelve lista de clases en las cual esta anotado el alumno con el dni ingresado
        /// </summary>
        /// <returns>Retorna lista de Clases</returns>
        [HttpGet]
        [Route("ClasesxAlumno")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Clase>>> GetClasesByDniAlumno([FromQuery] int dniAlumno)
        {
            
            var alumno = await _unitOfWork.UsuarioRepository.GetByDni(dniAlumno);
            int id = alumno.Id;
            var clases = await _unitOfWork.ClaseRepository.GetAllByIdAlumno(id);

            return clases;
        }

        /// <summary>
        /// muestra las clases en las cuales el alumno no esta anotado
        /// </summary>
        /// <returns>Retorna lista de tipo Clase</returns>
        //[Authorize(Policy = "AdminConsultor")]
        [HttpGet]
        [Route("ClasesRestantesxAlumno")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Clase>>> GetClasesRestantesByDniAlumno([FromQuery] int dniAlumno)
        {

            var alumno = await _unitOfWork.UsuarioRepository.GetByDni(dniAlumno);
            int id = alumno.Id;
            var clases = await _unitOfWork.ClaseRepository.GetClasesRestantesByIdAlumno(id);

            //return clases;
            return Ok(clases);
        }

        /// <summary>
        /// Agrega una Clase a la DB
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Ok(200) si se agrego bien o Error si hubo un error</returns>
        [HttpPost]
        [Authorize]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(ClaseDto dto)
        {
            if (await _unitOfWork.ClaseRepository.HorarioOcup(dto.FechaHorario)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe una clase con ese horario asignado");
            var clase = new Clase(dto);

            await _unitOfWork.ClaseRepository.Insert(clase);
            await _unitOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "Clase registrada con éxito!");
        }

        /// <summary>
        /// Actualiza la clase seleccionada por el id enviado por parametro
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
        /// Cambia a false el estado de la propiedad Activo de la clase seleccionada por id
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
        /// Recorre una lista de clases con Àctivo=true y si la Fecha y Hora son mayores a la fecha actual cambia Active=false
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se modifico con exito o 500 si hubo un error</returns>
        [Authorize]
        [HttpPut("ActualizacionClases")]
        public async Task<IActionResult> ActualizacionClases()
        {
            var result = await _unitOfWork.ClaseRepository.Actualizacion();
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar la clase");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }

        }


        /// <summary>
        /// Inscribe al alumno con el id ingresado en la clase del id ingresado, aumenta en una la propiedad cupos de la clase, tambien genera un historial donde queda registardo la inscripcion
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 si ingresaron id invalido</returns>
        [Authorize]
        [HttpPut("Inscripcion")]
        public async Task<IActionResult> Inscripcion([FromQuery] int idClase, [FromQuery] int dniAlumno)
        {
            var alumno = await _unitOfWork.UsuarioRepository.GetByDni(dniAlumno);
            int idAlumno = alumno.Id;
            //VALIDACION SI LA CLASE TIENE CUPOS

            var result = await _unitOfWork.ClaseRepository.Inscripcion(idClase, idAlumno);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo inscribir al usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }

        }


        /// <summary>
        /// Cancela la inscripcion del alumno con el id ingresado en la clase del id ingresado, resta uno la propiedad cupos de la clase, tambien genera un historial donde queda registardo la cancelacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 si ingresaron id invalido</returns>
        //[Authorize(Policy = "Admin")]
        [Authorize]
        [HttpPut("Cancelacion")]
        public async Task<IActionResult> Cancelacion([FromQuery] int idClase, [FromQuery] int dniAlumno)
        {
            var alumno = await _unitOfWork.UsuarioRepository.GetByDni(dniAlumno);
            int idAlumno = alumno.Id;
            //VALIDACION SI LA CLASE TIENE CUPOS

            var result = await _unitOfWork.ClaseRepository.Cancelacion(idClase, idAlumno);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo cancelar inscripcion");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }

        }

    }
}
