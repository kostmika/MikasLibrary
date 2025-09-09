using MikasLibrary.Interfaces;
using MikasLibrary.Models;

namespace MikasLibrary.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksDal _booksDal;
        private readonly IUsersDal _usersDal;

        public BooksService(IBooksDal booksDal, IUsersDal usersDal)
        {
            _booksDal = booksDal;
            _usersDal = usersDal;
        }

        public async Task AddBookAsync(Book book)
        {
            _booksDal.Add(book);
            await _booksDal.SaveChangesAsync();
        }

        public Task<List<Book>> GetAllAsync()
        {
            return _booksDal.GetAllAsync();
        }

        public async Task BorrowBookAsync(Guid bookId, string userNationalId)
        {
            Book book = await _booksDal.GetByIdAsync(bookId) ?? throw new KeyNotFoundException("Book not found");

            User user = await _usersDal.GetByNationalIdAsync(userNationalId) ?? throw new KeyNotFoundException("User not found");

            book.BorrowedBy = user.Id;
            book.BorrowDate = DateTime.Now;
            _booksDal.UpdateAsync(book);
            await _booksDal.SaveChangesAsync();
        }

        public async Task ReturnBookAsync(Guid bookId)
        {
            Book book = await _booksDal.GetByIdAsync(bookId) ?? throw new KeyNotFoundException("Book not found");
            book.BorrowedBy = null;
            book.BorrowDate = null;
            _booksDal.UpdateAsync(book);
            await _booksDal.SaveChangesAsync();
        }
    }
}
