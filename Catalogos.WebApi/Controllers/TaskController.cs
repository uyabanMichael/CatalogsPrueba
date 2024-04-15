using Catalogos.Business.Interfaces;
using Catalogos.Entities.Dto;
using Catalogos.Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace Catalogos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
       
        private readonly ILogger<TaskController> _logger;
        private readonly ICatalogs _catalogs;


        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }


        [HttpGet("tasks")]
        public async Task<ActionResult<taskOut>> GetTaskAsync()

        {
            var task = await _catalogs.Tasks.FindAsync();

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpGet("tasks/id")]
        public async Task<ActionResult<taskOut>> GetIdTasksync(task input)
        {
            var reg = await _catalogs.GetIdTaskAsync(input);

            if (reg == null)
            {
                return NotFound();
            }

            return reg;
        }

        [HttpPost("tasks")]
        public async Task<ActionResult<taskOut>> PostTask(task input)
        {
            var task = await _catalogs.AddTaskAsync(input);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }
    }
}
