using LibraryApp.Models.DTO;
using LibraryApp.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Test.Context;
using Test.DAL.Abstract;
using Test.DAL.GenericRepository;

namespace Test.DAL.Concrete
{
    public class BorrowBookRepository : GenericRepository<BorrowBooks>, IBorrowBooksRepository
    {
        private AppDbContext _context;

        public BorrowBookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Ödünç alınan kitapların ID listesini getiren metot
        public async Task<List<int>> GetAllBorrowBooksIdList()
        {
            return await _context.Set<BorrowBooks>().Select(book => book.Id).ToListAsync();
        }

        // Belirli bir ödünç alınan kitap ID'sine göre kitap ve ödünç alınan kitap bilgisini getiren metot
        public async Task<BookRegisterModel> GetBookBarrowBookInfoById(int barrowId)
        {
            return await _context.Set<BorrowBooks>()
                .Where(x => x.Id == barrowId)
                .Include(x => x.Book)
                .Select(y => new BookRegisterModel { Name = y.Book.Name, Author = y.Book.Author })
                .FirstOrDefaultAsync();
        }

        // Belirli bir ödünç alınan kitap ID'sine göre kullanıcı bilgisini getiren metot
        public async Task<UserRegisterModel> GetBookBarrowUserInfoById(int barrowId)
        {
            return await _context.Set<BorrowBooks>()
                .Where(x => x.Id == barrowId)
                .Include(x => x.User)
                .Select(y => new UserRegisterModel { Name = y.User.Name, Surname = y.User.Surname })
                .FirstOrDefaultAsync();
        }

        // Belirli bir kitap ID'sine göre ödünç alınmış kitap detayını getiren metot
        public async Task<BorrowBooks> GetBorrowBookDetailByBookId(int bookId)
        {
            return await _context.Set<BorrowBooks>().FirstOrDefaultAsync(x => x.BookId == bookId && x.ReturnDate == null);
        }
    }
}
