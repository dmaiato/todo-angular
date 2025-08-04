
using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
  private readonly ITaskService _service;

  public TasksController(ITaskService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
  {
    return Ok(await _service.GetAllTasksAsync());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<TaskItem>> GetTask(int id)
  {
    var task = await _service.GetTaskByIdAsync(id);
    return task == null ? NotFound() : Ok(task);
  }

  [HttpPost]
  public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
  {
    var createdTask = await _service.CreateTaskAsync(task);
    return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateTask(int id, TaskItem task)
  {
    if (id != task.Id)
    {
      return BadRequest("ID in URL does not match ID in body");
    }

    var (found, updatedTask) = await _service.UpdateTaskAsync(task);

    if (!found)
    {
      return NotFound($"Task with ID {id} not found");
    }

    return Ok(updatedTask);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteTask(int id)
  {
    var deleted = await _service.DeleteTaskAsync(id);

    if (!deleted)
    {
      return NotFound($"Task with ID {id} not found");
    }

    return NoContent();
  }


}