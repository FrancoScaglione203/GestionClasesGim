using GestionClasesGim.DataAccess.DataBaseSeeding;
using GestionClasesGim.Entities;
using Microsoft.EntityFrameworkCore;


namespace GestionClasesGim.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<TipoMov> TipoMovs { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new AlumnoSeeder(),
                new RoleSeeder(),
                new TipoMovSeeder(),
                new UsuarioSeeder(),
            };

            foreach (var seeder in seeders)
            {

                seeder.SeedDataBase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
