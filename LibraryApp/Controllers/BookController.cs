using LibraryApp.Models.DTO;
using LibraryApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Test.DAL.Abstract;


namespace Test.Controllers
{
   
    public class BookController : Controller
    {
        private  readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository, IBorrowBooksRepository borrowBooksRepository)
        {
            _bookRepository = bookRepository;

        }




        public async Task<IActionResult> AddBook()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromForm] BookRegisterModel book)
        {
            var imageName = book.ImagePath.FileName;
            Book model = new()
            {
                Name = book.Name,
                Author = book.Author,
                ImagePath= imageName,
            };
            await _bookRepository.Create(model);
            return View(book);
        }

     
        [HttpGet]
        public async Task<IActionResult> GetBookList()
        {
            var books = await _bookRepository.GetAll();

            return View(books); 
        }
        [HttpGet]
        public async Task<IActionResult> BookDetail(int bookId)
        {
            var book = await _bookRepository.GetById(bookId);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file,string title)
        {
            if (file != null)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/BookImages/{file.FileName}");

                using var stream = new FileStream(path, FileMode.Create);

                await file.CopyToAsync(stream);
            }

            return Ok();
        }

    }
}
