using GestionClasesGim.Entities;
using GestionClasesGim.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GestionClasesGim.DataAccess.DataBaseSeeding
{
    public class AlumnoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>().HasData(
                new Alumno
                {
                    Id = 2,
                    Dni = 20587469,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 20587469),
                    Nombre = "Maria Luz",
                    Apellido = "Avila",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/01/24", "dd/MM/yy", CultureInfo.InvariantCulture)
                });
        }
    }
}
