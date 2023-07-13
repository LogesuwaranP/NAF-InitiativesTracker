using InitiativesTracker.Data;
using InitiativesTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InitiativesTracker.Models.Request;

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
        public async Task<IActionResult> AddUser( RequestComments requestComments)
        {
            Comments c = new Comments();
            c.Comment = requestComments.Comment;
            c.CommentsDateOnly = DateTime.Now.ToShortDateString();
            c.CommentsTimeOnly = DateTime.Now.ToShortTimeString();
            c.UserId=requestComments.UserId;
            await _context.CommentsTable.AddAsync(c);
            await _context.SaveChangesAsync();
            return Ok(c);

        }
    }
}
