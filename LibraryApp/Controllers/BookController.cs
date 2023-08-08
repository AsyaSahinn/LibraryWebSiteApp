using LibraryApp.Models.DTO;
using LibraryApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Test.DAL.Abstract;

namespace Test.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository; // Kitap veritabanı işlemleri için arayüz
        private readonly IBorrowBooksRepository _borrowBooksRepository; // Ödünç kitap veritabanı işlemleri için arayüz

        public BookController(IBookRepository bookRepository, IBorrowBooksRepository borrowBooksRepository)
        {
            _bookRepository = bookRepository;
            _borrowBooksRepository = borrowBooksRepository;
        }

        // Yeni bir kitap ekleme sayfasını görüntülemek için kullanılan HTTP Get işlemi 
        public async Task<IActionResult> AddBook()
        {
            return View(); 
        }

        // Yeni bir kitap eklemek için kullanılan HTTP Post işlemi
        [HttpPost]
        public async Task<IActionResult> AddBook([FromForm] BookRegisterModel book)
        {
            if (string.IsNullOrEmpty(book.Name) || string.IsNullOrEmpty(book.Author) || book.ImagePath == null)
            {
                // Eksik bilgi hatası için Toastr kullanarak uyarı mesajı göster
                TempData["ErrorMessage"] = "Please fill in all fields.";
                return RedirectToAction("AddBook"); // Yönlendirme yapılacak sayfa adını buraya yazın
            }

            var imageName = book.ImagePath.FileName; //İmagePath file tipinde bir property olduğu için database'e kayıt işleminde string bir değer olan FileName bilgisi alınıyor.
            Book model = new()
            {
                Name = book.Name,
                Author = book.Author,
                ImagePath = imageName,
            };
            await _bookRepository.Create(model);
            return View(book);
        }

        // Tüm kitapları listelemek için kullanılan HTTP Get işlemi
        [HttpGet]
        public async Task<IActionResult> GetBookList()
        {
            var books = await _bookRepository.GetAll(); //GetBookList.cshmtl sayfasında görüntülenen kitapların listesi
            return View(books);
        }

        // Belirli bir kitabın detayını göstermek için kullanılan HTTP Get işlemi
        [HttpGet]
        public async Task<IActionResult> BookDetail(int bookId)
        {
            var book = await _bookRepository.GetById(bookId); //Kitap idsi anasayfada listelenen herhangi bir kitabın detayına gidilmek istendiğinde url içinden alınıyor
            // ve bu kitap idsi ile kitaba ait bilgilere erişiliyor.
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Kitap resmi yüklemek için kullanılan HTTP Post işlemi
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/BookImages/{file.FileName}"); //Kullanıcı tarafından seçilen kitap resmi $"wwwroot/BookImages/{file.FileName}" uzantılı dosyaya kayıt edilmek için path bilgisi alınıyor.
                using var stream = new FileStream(path, FileMode.Create);  
                await file.CopyToAsync(stream);
            }
            return Ok();
        }
    }
}
