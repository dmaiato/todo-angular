using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class TaskItem
{
  public int Id { get; set; }
  [Required(ErrorMessage = "Title is required")]
  [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3-100 characters")]
  public required string Title { get; set; }
  [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
  public string Description { get; set; } = string.Empty;

  [Required(ErrorMessage = "Status is required")]
  [RegularExpression("^(A Fazer|Em Andamento|Concluído)$",
  ErrorMessage = "Status must be 'A Fazer', 'Em Andamento', or 'Concluído'")]
  public string Status { get; set; } = "A Fazer";
}