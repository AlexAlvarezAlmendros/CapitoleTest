using Domain.Entities;
using System.Net.Http.Json;

namespace TaskAppCapitole.Client.Services
{
	public class TaskItemService
	{
		private readonly HttpClient _httpClient;

		public TaskItemService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<TaskItem>> GetTaskItemsAsync()
		{
            var response = await _httpClient.GetAsync("api/Task");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<TaskItem>>();
        }

		public async Task AddTaskItemAsync(TaskItem taskItem)
		{
            var response =  await _httpClient.PostAsJsonAsync("api/Task", taskItem);
            response.EnsureSuccessStatusCode();
        }

		public async Task UpdateTaskItemAsync(TaskItem taskItem)
		{
            var response = await _httpClient.PutAsJsonAsync($"api/Task/{taskItem.Id}", taskItem);
            response.EnsureSuccessStatusCode();
        }

		public async Task DeleteTaskItemAsync(string id)
		{
            var response = await _httpClient.DeleteAsync($"api/Task/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}
