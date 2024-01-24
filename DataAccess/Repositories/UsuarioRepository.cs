using GestionClasesGim.DataAccess.Repositories.Interfaces;
using GestionClasesGim.Entities;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
