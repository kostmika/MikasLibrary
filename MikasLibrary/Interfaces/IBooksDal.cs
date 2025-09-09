using MikasLibrary.Models;

namespace MikasLibrary.Interfaces
{
    public interface IBooksDal : IBaseDal<Book>
    {
        Task<Book?> GetByIdAsync(Guid id);

        Task<Book?> GetByTitleAsync(string title);

        void UpdateAsync(Book book);
    }
}
