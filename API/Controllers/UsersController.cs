using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // GET /api/users
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        // Dependency Injection of Parameters
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        // Create method to do the thing
        // public ActionResult<IEnumerable<AppUser>> GetUsers()
        // Make asyncronus
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //var users = _context.Users.ToList();
            var users = await _context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")]
        //public ActionResult<AppUser> GetUser(int id)
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //var user = _context.Users.Find(id);
            //return user;

            // or just:   return _context.Users.Find(id);

            return await _context.Users.FindAsync(id);

        }
    }
}