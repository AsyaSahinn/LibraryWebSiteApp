using LibraryApp.Models.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Test.Context;

namespace Test.DAL.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : TEntity
    {
        private AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
           var entity = await GetById(id);
            _context.Set<T>().Remove(entity);   
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task Create(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();

        }
        public async Task Update(T obj)
        {
            _context.Set<T>().Update(obj);
            await _context.SaveChangesAsync();  
        }
    }
}
