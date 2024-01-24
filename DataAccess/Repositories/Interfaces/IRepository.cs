namespace GestionClasesGim.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);
        public Task<bool> DeleteLogico(int id);
    }
}
