using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Interfaces;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoListContext _context;

        public ToDoService(ToDoListContext context) 
        {  
            _context = context; 
        }

        public async Task<IEnumerable<TaskToDo>> GetAllAsync()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<TaskToDo?> GetByIdAsync(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task AddAsync(TaskToDo item) 
        {
            await _context.ToDoItems.AddAsync(item);
        }

        public void Update(TaskToDo item)
        {
            _context.ToDoItems.Update(item);
        }

        public void Delete(TaskToDo item)
        {
            _context.ToDoItems.Remove(item);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
