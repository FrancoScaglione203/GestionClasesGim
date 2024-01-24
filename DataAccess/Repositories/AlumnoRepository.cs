using GestionClasesGim.DataAccess.Repositories.Interfaces;
using GestionClasesGim.Entities;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class AlumnoRepository : Repository<Alumno>, IAlumnoRepository
    {
        public AlumnoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
