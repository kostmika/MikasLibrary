using Microsoft.EntityFrameworkCore;
using MikasLibrary.Interfaces;
using MikasLibrary.Models;
using MikasLibrary.Utils;

namespace MikasLibrary.Dal
{
    public class UsersDal : BaseDal<User>, IUsersDal
    {
        public UsersDal(LibraryDBContext context) : base(context) { }

        public async Task<User> GetByNationalIdAsync(string nationalId)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.NationalId == nationalId);
        }
    }
}
