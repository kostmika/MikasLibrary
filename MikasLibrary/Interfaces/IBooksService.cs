using MikasLibrary.Models;

namespace MikasLibrary.Interfaces
{
    public interface IBooksService
    {
        Task AddBookAsync(Book book);

        Task<List<Book>> GetAllAsync();

        Task BorrowBookAsync(Guid bookId, string userNationalId);
        
        Task ReturnBookAsync(Guid bookId);
    }
}
