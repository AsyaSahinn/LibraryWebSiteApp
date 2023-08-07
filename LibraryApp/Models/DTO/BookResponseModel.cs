namespace LibraryApp.Models.DTO
{
    public class BookResponseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Author { get; set; }

        public string? IsBorrow { get; set; }

        public string? ImagePath { get; set; }
    }
}
