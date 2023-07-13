using InitiativesTracker.Data;
using InitiativesTracker.Models;

using InitiativesTracker.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InitiativesTracker.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class ApproverController : Controller
    {
        private readonly DataContext _context;

        public ApproverController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Users
        public async Task<IActionResult> GetAllProduct()
        {
            var AllUsers = await _context.Approvers.ToListAsync();
            return Ok(AllUsers);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Approver NewUser)
        {


            await _context.Approvers.AddAsync(NewUser);
            await _context.SaveChangesAsync();
            return Ok(NewUser);

        }


    }
}
