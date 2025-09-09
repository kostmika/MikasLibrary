using MikasLibrary.Models;

namespace MikasLibrary.Interfaces
{
    public interface IUsersDal : IBaseDal<User>
    {
        Task<User> GetByNationalIdAsync(string nationalId);
    }
}
