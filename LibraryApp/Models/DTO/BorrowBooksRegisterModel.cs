namespace LibraryApp.Models.DTO
{
    public class BorrowBooksRegisterModel
    {
        public int BookId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime BorrowDate { get; set; }

        public DateTime DueDate { get; set; }


    }
}
