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
                    FechaInscripcion = DateTime.ParseExact("21/01/24", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 3,
                    Dni = 52467894,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 52467894),
                    Nombre = "Natalia",
                    Apellido = "Scaglione",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/04/24", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 4,
                    Dni = 97852654,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 97852654),
                    Nombre = "Vicente",
                    Apellido = "Scaglione",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/08/22", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 5,
                    Dni = 23451474,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 23451474),
                    Nombre = "Facundo",
                    Apellido = "Barisano",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/01/24", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 6,
                    Dni = 56789845,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 56789845),
                    Nombre = "Eliana",
                    Apellido = "Croce",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/04/24", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 7,
                    Dni = 32347841,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 32347841),
                    Nombre = "Jaqueline",
                    Apellido = "Italia",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/08/22", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 8,
                    Dni = 87456548,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 87456548),
                    Nombre = "Jony",
                    Apellido = "Lozada",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/01/24", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 9,
                    Dni = 65986563,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 65986563),
                    Nombre = "Claudio",
                    Apellido = "Acosta",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("21/01/24", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 10,
                    Dni = 78981232,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 78981232),
                    Nombre = "Kim",
                    Apellido = "Garcia",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/04/24", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 11,
                    Dni = 56564564,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 56564564),
                    Nombre = "Ezequiel",
                    Apellido = "Vera",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/08/22", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 12,
                    Dni = 62616344,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 62616344),
                    Nombre = "Nicolas",
                    Apellido = "Leoni",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/01/24", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 13,
                    Dni = 56111243,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 56111243),
                    Nombre = "Marina",
                    Apellido = "Del Olio",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/04/24", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 14,
                    Dni = 64445121,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 64445121),
                    Nombre = "Manuel",
                    Apellido = "Ballarini",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/08/22", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                },
                new Alumno
                {
                    Id = 15,
                    Dni = 33265561,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 33265561),
                    Nombre = "Gabriela",
                    Apellido = "Solimano",
                    RoleId = 2,
                    Activo = true,
                    FechaInscripcion = DateTime.ParseExact("23/08/22", "dd/MM/yy", CultureInfo.InvariantCulture),
                    imagenUrl = " "
                });
        }
    }
}
