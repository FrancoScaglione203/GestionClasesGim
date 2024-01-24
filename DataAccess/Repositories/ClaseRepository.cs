using GestionClasesGim.DataAccess.Repositories.Interfaces;
using GestionClasesGim.Entities;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class ClaseRepository : Repository<Clase>, IClaseRepository
    {
        public ClaseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
