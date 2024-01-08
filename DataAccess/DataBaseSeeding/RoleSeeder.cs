using GestionClasesGim.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionClasesGim.DataAccess.DataBaseSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Admin",
                    Activo = true,

                },
                 new Role
                 {
                     Id = 2,
                     Name = "Alumno",
                     Description = "Alumno",
                     Activo = true,
                 });
        }
    }
}
