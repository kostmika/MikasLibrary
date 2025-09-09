using Microsoft.AspNetCore.Mvc;
using MikasLibrary.Interfaces;
using MikasLibrary.Models;

namespace MikasLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            var books = await _booksService.GetAllAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Book book)
        {
            await _booksService.AddBookAsync(book);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBorrow(Book book, string userNationalId)
        {
            try
            {
                if (book.BorrowedBy == null)
                {
                    await _booksService.BorrowBookAsync(book.Id, userNationalId);
                }
                else
                {
                    await _booksService.ReturnBookAsync(book.Id);
                }
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Book or user not found");
            }

            return Ok();
        }
    }
}
