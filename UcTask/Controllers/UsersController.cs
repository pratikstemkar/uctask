using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcTask.Data;
using UcTask.Models;

namespace UcTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TaskContext db;

        public UsersController(TaskContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = db.Users;
            if(users == null) {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            var location = Url.Action(nameof(Get), new { id = user.Id});

            return Created(location, user);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = db.Users.Include(u => u.Tasks)
                               .FirstOrDefault(u => u.Id == id);
            if(user == null) {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var userFound = db.Users.Find(id);
            if (userFound == null) {
                return NotFound();
            }

            userFound.Username = user.Username;
            userFound.Email = user.Email;
            db.SaveChanges();

            return Ok(userFound);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userFound = db.Users.Find(id);
            if (userFound == null) {
                return NotFound();
            }

            db.Users.Remove(userFound);
            db.SaveChanges();

            return NoContent();
        }
    }
}
