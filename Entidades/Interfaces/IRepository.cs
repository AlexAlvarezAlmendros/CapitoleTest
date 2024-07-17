using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository
	{
		public Task<List<TaskItem>> GetAllTasks();
		public Task AddTask(TaskItem task);
		public Task DeleteTask(string TaskId);
		public Task UpdateTask(TaskItem task);
	}
}
