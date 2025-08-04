using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class TaskItem
{
  public int Id { get; set; }
  public required string Title { get; set; }
  public string Description { get; set; } = string.Empty;
  public required string Status { get; set; }
}