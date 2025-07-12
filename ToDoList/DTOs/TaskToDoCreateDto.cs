using System.ComponentModel.DataAnnotations;

namespace ToDoList.DTOs
{
    public class TaskToDoCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool isCompleted { get; set; }
    }
}
