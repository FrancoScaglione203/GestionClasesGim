using GestionClasesGim.DataAccess.Repositories.Interfaces;
using GestionClasesGim.Entities;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
