
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InitiativesTracker.Data;
using InitiativesTracker.Models;

using InitiativesTracker.Models.Request;
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
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _context.Users.Select(user => new
            {
                name = user.Name,
                email = user.Email,
                role = _context.Roles.FirstOrDefault(role => role.Id == user.UserType).role,
            }).ToList();

            //var AllUsers = await _context.Users.ToListAsync();
            //List<ResponseUser> list = new List<ResponseUser>();
            //ResponseUser ru = new ResponseUser();
            //List<Users> listUser = await _context.Users.ToListAsync();


            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(RequestUser requestUser)
        {
                        
            var EmailCheck = _context.Users.FirstOrDefault(x => x.Email.Equals(requestUser.Email));
            if(EmailCheck != null) 
            {
                return BadRequest("Email Already Exist");
            }
            var UserCheck = _context.Users.FirstOrDefault(x => x.Email.Equals(requestUser.Email));
            if (UserCheck != null) 
            {
                return BadRequest("User Exist");
            }

        

            var password = requestUser.Password;
            byte[] encData_byte = new byte[password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            User u = new User();
            u.Email = requestUser.Email;
            u.Name = requestUser.Name;
            u.Password = encodedData;
            u.UserType = 2;
            
            await _context.Users.AddAsync(u);
            await _context.SaveChangesAsync();
            return Ok(u);
            
        }

        [HttpPost]
        [Route("/auth")]
        public async Task<IActionResult> UserAuth(RequestUser requestUser)
        {
            // Find the value by the id of the customer.
            string msg = "user not Found";
            var userSearch = _context.Users.FirstOrDefault(x => x.Email.Equals(requestUser.Email));
            if(userSearch == null)
            {
                return BadRequest(msg);
            }
            var password = requestUser.Password;
            byte[] encData_byte = new byte[password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            password = encodedData;
            
            userSearch = _context.Users.FirstOrDefault(x =>  x.Email.Equals(requestUser.Email)&& x.Password.Equals(password));

            if (userSearch != null)
            {

                var users = _context.Roles.FirstOrDefault(role => role.Id == userSearch.UserType);

                return Ok(new{userSearch.Id,userSearch.Email,userSearch.Name,users.role});
            }
            msg = "User and Password combo is wrong";
            return BadRequest(msg);
        }


    }
}
