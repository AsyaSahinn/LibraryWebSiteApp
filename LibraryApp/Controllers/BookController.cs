using LibraryApp.Models.DTO;
using LibraryApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Test.DAL.Abstract;


namespace Test.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class BookController : Controller
    {
        private  readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository, IBorrowBooksRepository borrowBooksRepository)
        {
            _bookRepository = bookRepository;

        }

        //[HttpPost]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromForm] BookRegisterModel book)
        {
            Book model = new()
            {
                Name = book.Name,
                Author = book.Author,
                ImagePath= book.ImagePath
            };
            await _bookRepository.Create(model);
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookList()
        {
            var books = await _bookRepository.GetAll();

            return View(books); ;
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


    }
}
