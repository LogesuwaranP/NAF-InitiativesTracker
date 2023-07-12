using InitiativesTracker.Data;
using InitiativesTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InitiativesTracker.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CommentsController :Controller
    {
        private readonly DataContext _context;

        public CommentsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Users
        public async Task<IActionResult> GetAllProduct()
        {
            var AllUsers = await _context.CommentsTable.ToListAsync();
            return Ok(AllUsers);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser( Comments NewUser)
        {
            NewUser.CommentsDateOnly = DateTime.Now.ToShortDateString();
            NewUser.CommentsTimeOnly = DateTime.Now.ToShortTimeString();
            await _context.CommentsTable.AddAsync(NewUser);
            await _context.SaveChangesAsync();
            return Ok(NewUser);

        }
    }
}
