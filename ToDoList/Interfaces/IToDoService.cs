using ToDoList.Models;

namespace ToDoList.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<TaskToDo>> GetAllAsync();
        Task<TaskToDo?> GetByIdAsync(int id);
        Task AddAsync(TaskToDo item);
        void Update(TaskToDo item);
        void Delete(TaskToDo item);
        Task<bool> SaveChangesAsync();
    }
}
