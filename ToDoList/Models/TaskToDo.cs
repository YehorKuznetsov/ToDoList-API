using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TaskToDo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }   
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
