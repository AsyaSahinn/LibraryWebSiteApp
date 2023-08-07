using LibraryApp.Models.DTO;
using LibraryApp.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test.DAL.Abstract;
using Test.DAL.Concrete;

namespace Test.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class BorrowBookController : Controller
    {
        private  IBorrowBooksRepository _borrowBooksRepository;
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;

        public BorrowBookController(IBorrowBooksRepository borrowBooksRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _borrowBooksRepository = borrowBooksRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }
     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBorrowBook([FromForm] BorrowBooksRegisterModel borrowBook)
        {
            int bookId = borrowBook.BookId;
            var user = await _userRepository.GetUserByNameAndSurname(borrowBook.UserName, borrowBook.UserSurname);
            BorrowBooks model = new()
            {
                UserId = user.Id,
                BookId = bookId,
                BorrowDate = DateTime.Now,
                DueDate = borrowBook.DueDate,
            };
            await _borrowBooksRepository.Create(model);
            var book = await _bookRepository.GetById(model.BookId);
            book.IsBorrow = true;
            await _bookRepository.Update(book);

            return RedirectToAction("GetBookList","Book");
        }
        [HttpGet]
        public async Task<IActionResult> GetBorrowBookList()
        {
            var borrowBooks = await _borrowBooksRepository.GetAll();
            return View(borrowBooks);
        }

        [HttpGet] 
        public async Task<IActionResult> GetBorrowBookDetailByBorrowId(int borrowId)
        {
            var barrowDetail = await _borrowBooksRepository.GetById(borrowId);
            var bookDetail = await _borrowBooksRepository.GetBookBarrowBookInfoById(barrowDetail.Id);
            var userDetail = await _borrowBooksRepository.GetBookBarrowUserInfoById(barrowDetail.Id);

            BorrowBookResponseModel model = new()
            {
                    Id = barrowDetail.Id,
                    BookName=bookDetail.Name,
                    Author=bookDetail.Author,
                    UserName=userDetail.Name,
                    UserSurname=userDetail.Surname,
                    ReturnDate = barrowDetail.ReturnDate ??  null,
                    BorrowDate = barrowDetail.BorrowDate,
                    DueDate = barrowDetail.DueDate,
            };

            return Ok(model);   
        }



    }
}
