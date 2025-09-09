using MikasLibrary.Interfaces;
using MikasLibrary.Models;

namespace MikasLibrary.Services
{
    public class UsersService : IUsersService
    {
        private IUsersDal _usersDal;

        public UsersService(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public async Task AddAsync(User user)
        {
            _usersDal.Add(user);
            await _usersDal.SaveChangesAsync();
        }

        public Task<List<User>> GetAllAsync()
        {
            return _usersDal.GetAllAsync();
        }
    }
}
