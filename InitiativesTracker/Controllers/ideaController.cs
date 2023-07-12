using InitiativesTracker.Data;
using InitiativesTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InitiativesTracker.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ideaController: Controller
    {
        private readonly DataContext _context;

        public ideaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Users
        public async Task<IActionResult> GetAllProduct()
        {
            var AllUsers = await _context.Ideatable.ToListAsync();
            return Ok(AllUsers);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] idealist NewUser)
        {
            await _context.Ideatable.AddAsync(NewUser);
            await _context.SaveChangesAsync();
            return Ok(NewUser);

        }

    }
}
