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
    }
}
