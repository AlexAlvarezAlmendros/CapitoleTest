using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Settings;
using MongoDB.Driver;
namespace Infrastructure.Repositories
{
    public class Repository : IRepository
	{
		private readonly IMongoCollection<TaskItem> _taskItems;

		public Repository(MongoDbSettings settings) {
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_taskItems = database.GetCollection<TaskItem>("TaskItems");
		}	

		public async Task AddTask(TaskItem task)
		{
			await _taskItems.InsertOneAsync(task);
		}

		public async Task DeleteTask(string TaskId)
		{
			await _taskItems.DeleteOneAsync(taskItem => taskItem.Id == TaskId);
		}

		public async Task<List<TaskItem>> GetAllTasks()
		{
			return await _taskItems.Find(_ => true).ToListAsync();
		}

		public async Task UpdateTask(TaskItem task)
		{
			await _taskItems.ReplaceOneAsync(t => t.Id == task.Id, task);
		}
	}
}
