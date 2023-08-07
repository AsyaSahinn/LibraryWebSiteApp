using LibraryApp.Models.Entity;
using Test.DAL.GenericRepository;

namespace Test.DAL.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByNameAndSurname(string name,string surname);
    }
}
