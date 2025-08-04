
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
  private readonly ITaskRepository _repository;

  public TasksController(ITaskRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
  {
    return Ok(await _repository.GetAllAsync());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<TaskItem>> GetTask(int id)
  {
    var task = await _repository.GetByIdAsync(id);
    return task == null ? NotFound() : Ok(task);
  }

  [HttpPost]
  public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
  {
    var createdTask = await _repository.CreateAsync(task);
    return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateTask(int id, TaskItem task)
  {
    if (id != task.Id) return BadRequest();
    await _repository.UpdateAsync(task);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteTask(int id)
  {
    await _repository.DeleteAsync(id);
    return NoContent();
  }


}