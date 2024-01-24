using GestionClasesGim.DataAccess.Repositories.Interfaces;
using GestionClasesGim.Entities;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class TipoMovRepository : Repository<TipoMov>, ITipoMovRepository
    {
        public TipoMovRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
