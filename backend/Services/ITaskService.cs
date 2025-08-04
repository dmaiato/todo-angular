using Backend.Models;

namespace Backend.Services;

public interface ITaskService
{
  Task<IEnumerable<TaskItem>> GetAllTasksAsync();
  Task<TaskItem?> GetTaskByIdAsync(int id);
  Task<TaskItem> CreateTaskAsync(TaskItem task);
  Task<(bool found, TaskItem? task)> UpdateTaskAsync(TaskItem task);
  Task<bool> DeleteTaskAsync(int id);
}