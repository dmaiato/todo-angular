using Task = Backend.Models.Task;
using TaskStatus = Backend.Models.TaskStatus;

namespace Backend.Services;

public static class TaskService
{
  static List<Task> Tasks { get; }
  static int nextId = 3;
  static TaskService()
  {
    Tasks = new List<Task>
    {
      new Task { Id = 1, Title = "Configurar o ambiente de desenvolvimento", Description = "Instalar o Node.js, Angular CLI e criar o projeto.", Status = TaskStatus.AFazer},
      new Task { Id = 2, Title = "Instalar Dependências", Description = "Instalar o TailwindCSS", Status = TaskStatus.AFazer}
    };
  }

  public static List<Task> GetAll() => Tasks;

  public static Task? Get(int id) => Tasks.FirstOrDefault(t => t.Id == id);

  public static void Add(Task task)
  {
    task.Id = nextId++;
    Tasks.Add(task);
  }

  public static void Delete(int id)
  {
    var task = Get(id);
    if (task == null) return;

    Tasks.Remove(task);
  }

  public static void Update(Task task)
  {
    var index = Tasks.FindIndex(t => t.Id == task.Id);
    if (index == -1) return;

    Tasks[index] = task;
  }
}