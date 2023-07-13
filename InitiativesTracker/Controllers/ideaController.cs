using InitiativesTracker.Data;
using InitiativesTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InitiativesTracker.Models.Request;

namespace InitiativesTracker.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class IdeaController: Controller
    {
        private readonly DataContext _context;

        public IdeaController(DataContext context)
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
        public async Task<IActionResult> AddUser(RequestIdea requestIdea)
        {
            IdeaList idea=new IdeaList();
            idea.TaskId = requestIdea.TaskId;
            idea.Title = requestIdea.Title;
            idea.Short_Description = requestIdea.Short_Description;
            idea.Long_Description = requestIdea.Long_Description;
            idea.Contributor = requestIdea.Contributor;
            idea.Status = requestIdea.Status;
            idea.Owner = requestIdea.Owner;
            await _context.Ideatable.AddAsync(idea);
            await _context.SaveChangesAsync();
            return Ok(idea);

        }

    }
}
