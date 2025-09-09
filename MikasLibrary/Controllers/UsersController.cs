using Microsoft.AspNetCore.Mvc;
using MikasLibrary.Interfaces;
using MikasLibrary.Models;

namespace MikasLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(User user)
        {
            await _usersService.AddAsync(user);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _usersService.GetAllAsync();
            return Ok(users);
        }
    }
}
