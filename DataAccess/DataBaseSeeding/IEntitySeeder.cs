using Microsoft.EntityFrameworkCore;

namespace GestionClasesGim.DataAccess.DataBaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDataBase(ModelBuilder modelBuilder);
    }
}
