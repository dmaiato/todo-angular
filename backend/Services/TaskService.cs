using Backend.Models;
using Backend.Repositories;

namespace Backend.Services;

public class TaskService : ITaskService
{
  private readonly ITaskRepository _repository;

  public TaskService(ITaskRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
  {
    return await _repository.GetAllAsync();
  }

  public async Task<TaskItem?> GetTaskByIdAsync(int id)
  {
    return await _repository.GetByIdAsync(id);
  }

  public async Task<TaskItem> CreateTaskAsync(TaskItem task)
  {
    if (string.IsNullOrWhiteSpace(task.Status) ||
        !TaskValues.All.Contains(task.Status))
    {
      task.Status = TaskValues.A_Fazer;
    }
    return await _repository.CreateAsync(task);
  }

  public async Task<(bool found, TaskItem? task)> UpdateTaskAsync(TaskItem task)
  {
    // Check if task exists
    var existingTask = await _repository.GetByIdAsync(task.Id);
    if (existingTask == null)
    {
      return (false, null);
    }

    // Validate status
    if (!TaskValues.All.Contains(task.Status))
    {
      throw new ArgumentException("Invalid status. Must be 'A fazer', 'Em Andamento', or 'Concluído'");
    }

    // Update properties
    existingTask.Title = task.Title;
    existingTask.Description = task.Description;
    existingTask.Status = task.Status;

    await _repository.UpdateAsync(existingTask);
    return (true, existingTask);
  }

  public async Task<bool> DeleteTaskAsync(int id)
  {
    var task = await _repository.GetByIdAsync(id);
    if (task == null)
    {
      return false;
    }

    await _repository.DeleteAsync(id);
    return true;
  }
}