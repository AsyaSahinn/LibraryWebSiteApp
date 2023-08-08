using LibraryApp.Models.Entity.Base;

namespace Test.DAL.GenericRepository
{
   
    // Bu sayede T tipindeki nesneler, BaseEntity sınıfından türetilmiş nesneler olmalıdır.
    public interface IGenericRepository<T> where T : TEntity
    {
        // Tiplerine göre farklı tipte nesneleri döndüren metotlar tanımlar.
        Task<IEnumerable<T>> GetAll(); // Tiplere özgü tüm nesneleri getirir.
        Task<T> GetById(int id); // Belirli bir nesneyi ID'ye göre getirir.

        // Yeni bir nesne oluşturmak, güncellemek ve silmek için metotlar tanımlar.
        Task Create(T obj); // Yeni bir nesneyi oluşturur.
        Task Update(T obj); // Bir nesneyi günceller.
        Task Delete(int id); // Belirli bir ID'ye sahip nesneyi siler.
    }
}
