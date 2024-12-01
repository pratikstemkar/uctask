using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcTask.Data;
using UcTask.Models;

namespace UcTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class TasksController : ControllerBase
    {
        private readonly TaskContext db;
        public TasksController(TaskContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = db.Tasks.Include(t => t.User).ToList();
            if (tasks == null) {
                return NotFound();
            }

            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UTask task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();

            var location = Url.Action(nameof(Get), new { id = task.Id });

            return Created(location, task);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = db.Tasks.Find(id);
            if (task == null) {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UTask task)
        {
            var taskFound = db.Tasks.Find(id);
            if (taskFound == null) {
                return NotFound();
            }

            taskFound.Title = task.Title;
            taskFound.Description = task.Description;
            db.SaveChanges();

            return Ok(taskFound);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var taskFound = db.Tasks.Find(id);
            if (taskFound == null) {
                return NotFound();
            }

            db.Tasks.Remove(taskFound);
            db.SaveChanges();

            return NoContent();
        }
    }
}
