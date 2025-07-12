using System.ComponentModel.DataAnnotations;

namespace ToDoList.DTOs
{
    public class TaskToDoReadDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;  
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
