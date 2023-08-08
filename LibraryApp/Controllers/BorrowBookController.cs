using Azure;
using LibraryApp.Models.DTO;
using LibraryApp.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test.DAL.Abstract;
using Test.DAL.Concrete;

namespace Test.Controllers
{
    public class BorrowBookController : Controller
    {
        private IBorrowBooksRepository _borrowBooksRepository; // Ödünç kitap veritabanı işlemleri için arayüz
        private IBookRepository _bookRepository; // Kitap veritabanı işlemleri için arayüz
        private IUserRepository _userRepository; // Kullanıcı veritabanı işlemleri için arayüz

        public BorrowBookController(IBorrowBooksRepository borrowBooksRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _borrowBooksRepository = borrowBooksRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        // Yeni bir ödünç kitap eklemek için kullanılan HTTP Post işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBorrowBook([FromForm] BorrowBooksRegisterModel borrowBook)
        {
            int bookId = borrowBook.BookId; 
            var user = await _userRepository.GetUserByNameAndSurname(borrowBook.UserName, borrowBook.UserSurname); //Ödünç alma işleminde alınan username ve usersurname bilgileri ile 
            //kullanıcıya erişiliyor.

            BorrowBooks model = new()
            {
                UserId = user.Id, //BorrowBooks tablosund UserId ve BookId bilgileri user ve book tablolarından alınan foreign keyler olduğu için bu bilgiler tablolarda var olan
                BookId = bookId, //kitap ve kullanıcılara ait olmalıdır. 
                BorrowDate = DateTime.Now, // Kitabı ödünç alan kişinin ödünç alma tarihi 
                DueDate = borrowBook.DueDate, //Kitabı geri verme tarihi
            };

            await _borrowBooksRepository.Create(model); // Ödünç kitap veritabanına ekleniyor

            var book = await _bookRepository.GetById(model.BookId);//primary key olan bookid bilgisi ile kitabın IsBorrow bilgisi true olarak güncelleniyor.
            book.IsBorrow = true;
            await _bookRepository.Update(book); // Kitap durumu güncelleniyor

            return RedirectToAction("GetBookList", "Book"); // "Book" denetleyicisinin "GetBookList" metodu çağrılıyor
        }


        // Tüm ödünç kitapları listelemek için kullanılan HTTP Get işlemi
        [HttpGet]
        public async Task<IActionResult> GetBorrowBookList()
        {
            var borrowBooks = await _borrowBooksRepository.GetAll(); 
            return View(borrowBooks);
        }

        // Belirli bir kitaba ait ödünç kitap detayını getirmek için kullanılan HTTP Get işlemi
        [HttpGet]
        public async Task<IActionResult> GetBorrowBookDetailByBookId(int bookId)
        {
            var barrowDetail = await _borrowBooksRepository.GetBorrowBookDetailByBookId(bookId); //ödünç alınan kitabın bilgileri alınıyor.
            var bookDetail = await _borrowBooksRepository.GetBookBarrowBookInfoById(barrowDetail.Id);//Detay sayfasında görüntülemek için kitap bilgileri alınıyor.
            var userDetail = await _borrowBooksRepository.GetBookBarrowUserInfoById(barrowDetail.Id);//Detay sayfasında görüntülemek için kullanıcı bilgileri alınıyor.

            BorrowBookResponseModel model = new()
            {
                Id = barrowDetail.Id,
                BookName = bookDetail.Name,
                Author = bookDetail.Author,
                UserName = userDetail.Name,
                UserSurname = userDetail.Surname,
                ReturnDate = barrowDetail.ReturnDate.ToString() ?? "null", //Return date kitabı geri verme işleminde doldurulacağı için null olarak atanıyor.
                BorrowDate = barrowDetail.BorrowDate.ToShortDateString(),
                DueDate = barrowDetail.DueDate.ToShortDateString(),
            };

            return Ok(model);
        }
    }
}
