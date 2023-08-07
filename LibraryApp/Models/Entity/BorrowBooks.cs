using LibraryApp.Models.Entity.Base;

namespace LibraryApp.Models.Entity
{
    public class BorrowBooks : TEntity
    {

        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public Book Book { get; set; }

        public User User { get; set; }
    }
}
