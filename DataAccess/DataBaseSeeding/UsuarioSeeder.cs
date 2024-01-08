using GestionClasesGim.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionClasesGim.DataAccess.DataBaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Dni = 41826520,
                    Clave = "1234", //DESPUES ENCRIPTARLA
                    Nombre = "Franco",
                    Apellido = "Scaglione",
                    RoleId = 1,
                    Activo = true
                });
        }
    }
}
