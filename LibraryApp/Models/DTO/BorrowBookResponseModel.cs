using System.Globalization;

namespace LibraryApp.Models.DTO
{
    public class BorrowBookResponseModel
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public DateTime? ReturnDate { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime DueDate { get; set; }
    }
}
