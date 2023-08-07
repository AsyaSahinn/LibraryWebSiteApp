using LibraryApp.Models.Entity;
using Test.DAL.GenericRepository;

namespace Test.DAL.Abstract
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}
