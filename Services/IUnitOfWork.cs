using GestionClasesGim.DataAccess.Repositories;

namespace GestionClasesGim.Services
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Define una interfaz para acceder a los repositorios relacionados con las entidades de la base de datos.
        /// </summary>
        public AlumnoRepository AlumnoRepository { get; }
        public UsuarioRepository UsuarioRepository { get; }
        public ClaseRepository ClaseRepository { get; }
        public HistorialRepository HistorialRepository { get; }
        public TipoMovRepository TipoMovRepository { get; }
        public RoleRepository RoleRepository { get; }
        Task<int> Complete();
    }
}
