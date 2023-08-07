using LibraryApp.Models.DTO;
using LibraryApp.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Net;
using Test.Context;
using Test.DAL.Abstract;
using Test.DAL.GenericRepository;

namespace Test.DAL.Concrete
{
    public class BorrowBookRepository : GenericRepository<BorrowBooks> , IBorrowBooksRepository
    {
        private AppDbContext _context;
        public BorrowBookRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<int>> GetAllBorrowBooksIdList()
        {
           return await _context.Set<BorrowBooks>().Select(book => book.Id).ToListAsync();
        }

        public async Task<BookRegisterModel> GetBookBarrowBookInfoById(int barrowId)
        {
           return  await _context.Set<BorrowBooks>().Where(x => x.Id ==  barrowId).Include(x => x.Book) .Select(y => new BookRegisterModel { Name = y.Book.Name, Author = y.Book.Author,}).FirstOrDefaultAsync();

           
        }

        public async Task<UserRegisterModel> GetBookBarrowUserInfoById(int barrowId)
        {
            return await _context.Set<BorrowBooks>().Where(x => x.Id ==  barrowId).Include(x => x.User).Select(y => new UserRegisterModel { Name = y.User.Name,Surname =y.User.Surname}).FirstOrDefaultAsync();

        }

        public async Task<BorrowBooks> GetBorrowBookDetailByBookId(int bookId)
        {
            return await _context.Set<BorrowBooks>().FirstOrDefaultAsync(x=>x.BookId==bookId && x.ReturnDate==null);
        }
    }
}
