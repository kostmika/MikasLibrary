using MikasLibrary.Interfaces;
using MikasLibrary.Models;
using MikasLibrary.Utils;

namespace MikasLibrary.Dal
{
    public class BooksDal : BaseDal<Book>, IBooksDal
    {
        public BooksDal(LibraryDBContext context) : base(context) { }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book?> GetByTitleAsync(string title)
        {
            return await _context.Books.FindAsync(title);
        }

        public void UpdateAsync(Book book)
        {
            _context.Books.Update(book);
        }
    }
}
