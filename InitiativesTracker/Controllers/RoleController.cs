using InitiativesTracker.Data;
using InitiativesTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InitiativesTracker.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class RoleController:Controller
    {
        private readonly DataContext _context;

        public RoleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Users
        public async Task<IActionResult> GetAllProduct()
        {
            var AllUsers = await _context.Roles.ToListAsync();
            return Ok(AllUsers);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Role NewUser)
        {

           
            await _context.Roles.AddAsync(NewUser);
            await _context.SaveChangesAsync();
            return Ok(NewUser);

        }

    }
}
