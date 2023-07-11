
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InitiativesTracker.Data;
using InitiativesTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace InitiativesTracker.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Users
        public async Task<IActionResult> GetAllProduct()
        {
            var AllUsers = await _context.Users.ToListAsync();
            return Ok(AllUsers);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User NewUser)
        {
            
            var EmailCheck = _context.Users.FirstOrDefault(x => x.Email.Equals(NewUser.Email));
            if(EmailCheck != null) 
            {
                return BadRequest("Email Already Exist");
            }
            var UserCheck = _context.Users.FirstOrDefault(x => x.Email.Equals(NewUser.Email));
            if (UserCheck != null) 
            {
                return BadRequest("User Exist");
            }

            var password = NewUser.Password;
            byte[] encData_byte = new byte[password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            NewUser.Password = encodedData;
            await _context.Users.AddAsync(NewUser);
            await _context.SaveChangesAsync();
            return Ok(NewUser);
            
        }

        [HttpPost]
        [Route("/auth")]
        public string UserAuth([FromBody] User authUser)
        {
            // Find the value by the id of the customer.
            string msg = "user not Found";
            var userSearch = _context.Users.FirstOrDefault(x => x.Email.Equals(authUser.Email));
            if(userSearch == null)
            {
                return msg;
            }
            var password = authUser.Password;
            byte[] encData_byte = new byte[password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            authUser.Password = encodedData;
            userSearch = _context.Users.FirstOrDefault(x =>  x.Email.Equals(authUser.Email)&& x.Password.Equals(authUser.Password));

            if (userSearch != null)
            {
                return userSearch.UserType;
            }
            msg = "User and Password combo is wrong";
            return msg;
        }


    }
}
