using LibraryApp.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Test.Context
{

    public class AppDbContext : DbContext
    {
        // AppDbContext sınıfının yapıcı metodu, DbContextOptions<AppDbContext> türündeki
        // seçenekleri alır ve temel sınıfa (DbContext) bu seçenekleri ileterek veritabanı bağlantısını oluşturur.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Bu sınıfta veritabanında temsil edilecek nesneleri (entity) DbSet<> özellikleri olarak tanımlar.
        public DbSet<User> User { get; set; } // Kullanıcı nesnelerini temsil eder
        public DbSet<Book> Book { get; set; } // Kitap nesnelerini temsil eder
        public DbSet<BorrowBooks> BorrowBooks { get; set; } // Ödünç alınan kitapları temsil eder

        // Bu metot, veritabanı modelinin oluşturulma şeklini özelleştirmek için kullanılır.
        // Veritabanı tablolarının yapılandırması bu metot içinde yapılabilir.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(); // Kullanıcı tablosunu oluşturur
            modelBuilder.Entity<Book>(); // Kitap tablosunu oluşturur
            modelBuilder.Entity<BorrowBooks>(); // Ödünç kitaplar tablosunu oluşturur
        }
    }
}
