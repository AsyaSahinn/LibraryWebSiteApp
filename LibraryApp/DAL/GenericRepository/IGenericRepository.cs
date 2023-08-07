using LibraryApp.Models.Entity.Base;

namespace Test.DAL.GenericRepository
{
    public interface IGenericRepository<T> where T : TEntity
    {
         Task<IEnumerable<T>> GetAll();
         Task<T> GetById(int id);
         Task Create(T obj);
         Task Update(T obj);
         Task Delete(int id);
    }
}
