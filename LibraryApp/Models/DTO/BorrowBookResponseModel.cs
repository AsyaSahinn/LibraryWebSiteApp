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

        public string? ReturnDate { get; set; }

        public string BorrowDate { get; set; }

        public string DueDate { get; set; }
    }
}
