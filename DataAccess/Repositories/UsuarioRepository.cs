using GestionClasesGim.DataAccess.Repositories.Interfaces;
using GestionClasesGim.DTOs;
using GestionClasesGim.Entities;
using GestionClasesGim.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.Include(x => x.Role).SingleOrDefaultAsync(x => x.Dni == dto.Dni && x.Clave == PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Dni));
        }

        public async Task<bool> UsuarioEx(long dni)
        {
            return await _context.Usuarios.AnyAsync(x => x.Dni == dni);
        }

        public async Task<int> IdxDni(int dni)
        {
            var usuario = _context.Set<Usuario>().FirstOrDefaultAsync(u => u.Dni == dni);
            return usuario.Id;
        }

        /// <summary>
        /// Devuelve usuario sin clave por seguridad
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna usuario con la clave tapada por seguridad</returns>
        public async Task<Usuario> GetByDni(int dni)
        {
            Usuario usuarioreturn = new Usuario();
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Dni == dni);


            if (usuario == null)
            {
                return usuario;
            }
            else
            {
                usuarioreturn.Id = usuario.Id;
                usuarioreturn.Nombre = usuario.Nombre;
                usuarioreturn.Dni = usuario.Dni;
                usuarioreturn.Apellido = usuario.Apellido;
                usuarioreturn.RoleId = usuario.RoleId;
                usuarioreturn.Clave = usuario.Clave;
                usuarioreturn.Activo = usuario.Activo;
            }
            return usuarioreturn;
        }

        /// <summary>
        /// Actualiza el usuario con el id de updateUsuario por el mismo 
        /// </summary>
        /// <param name="updateUsuario"></param>
        /// <returns>Retorna true si se actualizo o false si hubo algun error</returns>
        public override async Task<bool> Update(Usuario updateUsuario)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == updateUsuario.Id);
            if (usuario == null) { return false; }

            usuario.Nombre = updateUsuario.Nombre;
            usuario.Apellido = updateUsuario.Apellido;
            usuario.RoleId = updateUsuario.RoleId;
            usuario.Dni = updateUsuario.Dni;
            usuario.Clave = updateUsuario.Clave;
            usuario.Activo = updateUsuario.Activo;

            _context.Usuarios.Update(usuario);
            return true;
        }

        public async Task<bool> DeleteLogico(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario == null) { return false; }

            usuario.Activo = false;

            _context.Usuarios.Update(usuario);
            return true;
        }

        public async Task<List<Usuario>> GetAllActivos()
        {
            var activeUsuarios = await _context.Usuarios.Where(x => x.Activo == true).ToListAsync();
            return activeUsuarios;
        }
    }
}
