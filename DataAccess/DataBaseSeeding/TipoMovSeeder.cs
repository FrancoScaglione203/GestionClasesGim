using GestionClasesGim.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionClasesGim.DataAccess.DataBaseSeeding
{
    public class TipoMovSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoMov>().HasData(
                new TipoMov
                {
                    Id = 1,
                    Descripcion = "Inscripcion"
                },
                new TipoMov
                {
                    Id = 2,
                    Descripcion = "Cancelacion"
                });
        }
    }
}
