using LibraryApp.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Test.Context;
using Test.DAL.Abstract;
using Test.DAL.GenericRepository;

namespace Test.DAL.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // İsim ve soyisime göre kullanıcı bilgisini getiren metot
        public async Task<User> GetUserByNameAndSurname(string name, string surname)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(x => x.Name == name && x.Surname == surname);
        }
    }
}
