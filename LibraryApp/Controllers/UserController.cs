using LibraryApp.Models.DTO;
using LibraryApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Test.DAL.Abstract;


namespace Test.Controllers
{
    
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserRegisterModel user)
        {
            User model = new()
            {
                Name = user.Name,
                Surname = user.Surname,
            };
            await _userRepository.Create(model);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var books = await   _userRepository.GetAll();
            return Ok(books);
        }
    }
}
