using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using MongoDB.Driver;
using TaskAPICapitole;
using Xunit;
using Xunit.Abstractions;

public class TaskItemsControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
	private readonly WebApplicationFactory<Program> _factory;
	private readonly ITestOutputHelper _output;

	public TaskItemsControllerTests(WebApplicationFactory<Program> factory, ITestOutputHelper output)
	{
		_factory = factory.WithWebHostBuilder(builder =>
		{
			builder.ConfigureLogging(logging =>
			{
				logging.AddXUnit(output);
			});
		});
		_output = output;
	}

	[Fact]
	public async Task Get_ReturnsAllTasks()
	{
		// Arrange
		var client = _factory.CreateClient();

		// Act
		var response = await client.GetAsync("/api/Task");

		// Assert
		response.EnsureSuccessStatusCode();
		var tasks = await response.Content.ReadFromJsonAsync<List<TaskItem>>();
		Assert.NotNull(tasks);
	}

	[Fact]
	public async Task Post_CreatesNewTask()
	{
		// Arrange
		var client = _factory.CreateClient();
		var newTask = new TaskItem { Name = "Test Task" };

		// Act
		var response = await client.PostAsJsonAsync("/api/Task", newTask);

		// Assert
		response.EnsureSuccessStatusCode();
		var task = await response.Content.ReadFromJsonAsync<TaskItem>();
		Assert.NotNull(task);
		Assert.Equal("Test Task", task.Name);
	}

	[Fact]
	public async Task Put_UpdatesTask()
	{
		// Arrange
		var client = _factory.CreateClient();
		var updateTask = new TaskItem { Id = "1", Name = "Updated Task" };

		// Act
		var response = await client.PutAsJsonAsync("/api/Task/1", updateTask);

		// Assert
		response.EnsureSuccessStatusCode();
	}

	[Fact]
	public async Task Delete_RemovesTask()
	{
		// Arrange
		var client = _factory.CreateClient();

		// Act
		var response = await client.DeleteAsync("/api/Task/1");

		// Assert
		response.EnsureSuccessStatusCode();
	}
}
