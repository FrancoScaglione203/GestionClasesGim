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
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAllActivos();

            return usuarios;
        }

     

        /// <summary>
        /// Agrega un Usuario a la DB
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Ok(200) si se agrego bien o Error si hubo un error</returns>
        [HttpPost]
        [Authorize]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(UsuarioDto dto)
        {
            if (await _unitOfWork.UsuarioRepository.UsuarioEx(dto.Dni)) return ResponseFactory.CreateErrorResponse(409,$"Ya existe un usuario registrado con el dni {dto.Dni}");
            var usuario = new Usuario(dto);

            await _unitOfWork.UsuarioRepository.Insert(usuario);
            await _unitOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con éxito!");
        }

        /// <summary>
        /// Actualiza usuario seleccionado por dni por el UsuarioDto que se envia
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="dto"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 si ingresaron id invalido</returns>
        //[Authorize(Policy = "Admin")]
        [Authorize]
        [HttpPut("Editar")]
        public async Task<IActionResult> Update([FromQuery] int dni, [FromBody] UsuarioDto dto)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetByDni(dni);
            int id = usuario.Id;
            var result = await _unitOfWork.UsuarioRepository.Update(new Usuario(dto, id));
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
        /// Cambia a false el estado de la propiedad Activo del usuario seleccionado por dni
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>Retorna 200 si se modifico con exito o 500 si hubo un error</returns>
        [Authorize]
        [HttpPut("DeleteLogico")]
        public async Task<IActionResult> DeleteLogico([FromQuery] int dni)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetByDni(dni);
            int id = usuario.Id;
            var result = await _unitOfWork.UsuarioRepository.DeleteLogico(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }

        }

    }
}
