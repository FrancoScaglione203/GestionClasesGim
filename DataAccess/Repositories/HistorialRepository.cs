using GestionClasesGim.DataAccess.Repositories.Interfaces;
using GestionClasesGim.Entities;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class HistorialRepository : Repository<Historial>, IHistorialRepository
    {
        public HistorialRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
