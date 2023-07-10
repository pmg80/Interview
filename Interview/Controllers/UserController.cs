using Interview.Data;
using Interview.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public readonly TaskManagerContext _context;
        public UserController(TaskManagerContext context)
        {
            _context = context;
        }
        /*[HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null) return BadRequest("user not found");
            if (user.Password == password) return Ok(" ");
            return BadRequest("wrong password");
        }*/
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return _context.Users.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpPost]
        public ActionResult<User> AddUser(string userName, string password, int roleId, int personId)
        {
            
            User user = new User()
            {

                InsDate = DateTime.Now,
                RoleId = roleId,
                PersonId = personId,
                UserName = userName,
                Password = password,

                
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) return NotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok("User Removed");
        }
        [HttpPut]
        public ActionResult<User> UpdatePerson(int id , string userName, string password, int roleId, int personId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) return NotFound();

            user.UserName = userName;
            user.Password = password;
            user.RoleId = roleId;
            user.PersonId = personId;



            _context.SaveChanges();
            return user;
        }
    }
}
