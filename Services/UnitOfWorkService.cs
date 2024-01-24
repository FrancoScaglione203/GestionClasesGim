using GestionClasesGim.DataAccess;
using GestionClasesGim.DataAccess.Repositories;

namespace GestionClasesGim.Services
{
    /// <summary>
    /// Implementación de la interfaz IUnitOfWork que proporciona acceso a los repositorios de entidades de la base de datos
    /// </summary>
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        

        public AlumnoRepository AlumnoRepository { get; private set; }
        public UsuarioRepository UsuarioRepository { get; private set; }
        public ClaseRepository ClaseRepository { get; private set; }
        public HistorialRepository HistorialRepository { get; private set; }
        public TipoMovRepository TipoMovRepository { get; private set; }
        public RoleRepository RoleRepository { get; private set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase UnitOfWorkService con el contexto de base de datos proporcionado
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            AlumnoRepository = new AlumnoRepository(_context);
            UsuarioRepository = new UsuarioRepository(_context);
            ClaseRepository = new ClaseRepository(_context);
            HistorialRepository = new HistorialRepository(_context);
            TipoMovRepository = new TipoMovRepository(_context);
            RoleRepository = new RoleRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
