using MikasLibrary.Models;

namespace MikasLibrary.Interfaces
{
    public interface IUsersService
    {
        Task AddAsync(User user);

        Task<List<User>> GetAllAsync();

    }
}
