using Application.Funcionalities;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class TaskServiceTests
{
	private readonly Mock<IRepository> _taskItemRepositoryMock;
	private readonly TaskService _taskService;

	public TaskServiceTests()
	{
		_taskItemRepositoryMock = new Mock<IRepository>();
		_taskService = new TaskService(_taskItemRepositoryMock.Object);
	}

	[Fact]
	public async Task GetAllTasks_ShouldReturnAllTasks()
	{
		// Arrange
		var tasks = new List<TaskItem>
		{
			new TaskItem { Id = "1", Name = "Task 1", IsCompleted = false, IsFavorite = false },
			new TaskItem { Id = "2", Name = "Task 2", IsCompleted = true, IsFavorite = false }
		};

		_taskItemRepositoryMock.Setup(repo => repo.GetAllTasks()).ReturnsAsync(tasks);

		// Act
		var result = await _taskService.GetAllTasks();

		// Assert
		Assert.Equal(2, result.Count());
		_taskItemRepositoryMock.Verify(repo => repo.GetAllTasks(), Times.Once);
	}

	[Fact]
	public async Task AddTask_ShouldAddTask()
	{
		// Arrange
		var newTask = new TaskItem { Name = "New Task" };

		_taskItemRepositoryMock.Setup(repo => repo.AddTask(newTask)).Returns(Task.CompletedTask);

		// Act
		await _taskService.AddTask(newTask);

		// Assert
		_taskItemRepositoryMock.Verify(repo => repo.AddTask(newTask), Times.Once);
	}

	[Fact]
	public async Task UpdateTask_ShouldUpdateTask()
	{
		// Arrange
		var existingTask = new TaskItem { Id = "1", Name = "Existing Task" };

		_taskItemRepositoryMock.Setup(repo => repo.UpdateTask(existingTask)).Returns(Task.CompletedTask);

		// Act
		await _taskService.UpdateTask(existingTask);

		// Assert
		_taskItemRepositoryMock.Verify(repo => repo.UpdateTask(existingTask), Times.Once);
	}

	[Fact]
	public async Task DeleteTask_ShouldDeleteTask()
	{
		// Arrange
		var taskId = "1";

		_taskItemRepositoryMock.Setup(repo => repo.DeleteTask(taskId)).Returns(Task.CompletedTask);

		// Act
		await _taskService.DeleteTask(taskId);

		// Assert
		_taskItemRepositoryMock.Verify(repo => repo.DeleteTask(taskId), Times.Once);
	}
}
