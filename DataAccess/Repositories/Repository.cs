using GestionClasesGim.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devuelve lista de clase generica
        /// </summary>
        /// <returns>Retorna lista de objetos tipo T</returns>
        public virtual async Task<List<T>> GetAll()
        {
            var TrabajoIntegradorSofttek = await _context.Set<T>().ToListAsync();
            return TrabajoIntegradorSofttek;
        }

        /// <summary>
        /// Inserta objeto tipo T en base de datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Retorna true luego de insertar el objeto</returns>
        public virtual async Task<bool> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return true;
        }


        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLogico(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Devuelve objeto tipo T con id enviado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna el objeto tipo T con el id enviado</returns>
        public virtual async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }
    }
}
