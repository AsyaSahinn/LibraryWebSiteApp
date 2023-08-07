using LibraryApp.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Test.Context;
using Test.DAL.Abstract;
using Test.DAL.GenericRepository;

namespace Test.DAL.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private AppDbContext _context;

        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
