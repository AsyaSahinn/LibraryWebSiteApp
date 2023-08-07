using System.Threading.Tasks;
using LibraryApp.Models.DTO;
using LibraryApp.Models.Entity;
using Test.DAL.GenericRepository;

namespace Test.DAL.Abstract
{
    public interface IBorrowBooksRepository : IGenericRepository<BorrowBooks>
    {
        Task<UserRegisterModel> GetBookBarrowUserInfoById(int userId);

        Task<BookRegisterModel> GetBookBarrowBookInfoById(int bookId);

        Task<BorrowBooks> GetBorrowBookDetailByBookId(int bookId); 
        Task<List<int>> GetAllBorrowBooksIdList();
    }
}
