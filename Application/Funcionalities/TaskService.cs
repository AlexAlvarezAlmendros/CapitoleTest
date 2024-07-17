using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
namespace Application.Funcionalities
{
    public class TaskService : ITaskService
	{
		private IRepository _repoService;

		public TaskService(IRepository repoService)
		{
			_repoService = repoService;
		}

		public async Task AddTask(TaskItem task)
		{
			await _repoService.AddTask(task);
		}

		public async Task DeleteTask(string TaskId)
		{
			await _repoService.DeleteTask(TaskId);
		}

		public async Task<List<TaskItem>> GetAllTasks()
		{
			List<TaskItem> taskItems = await _repoService.GetAllTasks();
			return taskItems == null ? new List<TaskItem>() : taskItems;
		}

		public async Task UpdateTask(TaskItem task)
		{
			await _repoService.UpdateTask(task);
		}
	}
}
