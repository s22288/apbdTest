using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public readonly dbContext _context;

        public HomeController(dbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProjectData(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            var tasks = _context.Tasks.Where(t => t.IdTeam == id)
                                       .OrderByDescending(t => t.Deadline)
                                       .ToList();

            return new Project
            {
                Name = project.Name,
                Tasks = tasks
            };
        }
        [HttpPost]
        public async Task<IActionResult> AddTask(Models.Task taskData)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var taskType = await _context.TaskTypes.FirstOrDefaultAsync(x => x.Name == taskData.TaskType.Name);
                    if (taskType == null)
                    {
                        taskType = new TaskType { Name = taskData.TaskType.Name };
                        _context.TaskTypes.Add(taskType);
                        await _context.SaveChangesAsync();
                    }

                    var task = new Models.Task
                    {
                        Name = taskData.Name,
                        Deadline = taskData.Deadline,
                        TaskType = taskType
                    };
                    _context.Tasks.Add(task);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return CreatedAtAction(nameof(Models.Task), new { id = task.IdTask }, task);
                }
                catch (DbUpdateException)
                {
                    transaction.Rollback();
                    return StatusCode(500, "Internal Server Error");
                }
            }
        }

    }



}