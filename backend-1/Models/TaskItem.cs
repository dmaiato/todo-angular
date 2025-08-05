using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; } = "A Fazer"; // Default status
    }
}