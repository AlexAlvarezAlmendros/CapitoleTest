using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITaskService
	{
		public Task<List<TaskItem>> GetAllTasks();
		public Task AddTask(TaskItem task);
		public Task DeleteTask(string TaskId);
		public Task UpdateTask(TaskItem task);
	}
}
