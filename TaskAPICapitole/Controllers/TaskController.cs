using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPICapitole.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskController : ControllerBase
	{

		private readonly ITaskService _taskService;

		public TaskController(ITaskService taskService)
		{
			_taskService = taskService;
		}

		[HttpGet]
		public async Task<ActionResult<List<TaskItem>>> Get()
		{
			List<TaskItem> tasks = await _taskService.GetAllTasks();
            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] TaskItem task)
		{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _taskService.AddTask(task);
			return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Put(string id, [FromBody] TaskItem task)
		{
			if (id != task.Id)
			{
				return BadRequest();
			}
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _taskService.UpdateTask(task);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			await _taskService.DeleteTask(id);
			return NoContent();
		}
	}
}