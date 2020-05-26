using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTrello.Domain.Repositories;
using MyTrello.Persistance.Contexts;

namespace MyTrello.Persistance.Repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context){}
        public async System.Threading.Tasks.Task AddAsync(Domain.Models.Task newTask)
        {
            await context.Tasks.AddAsync(newTask);
        }

        public void Delete(Domain.Models.Task task)
        {
            context.Tasks.Remove(task);
        }

        public async Task<IEnumerable<Domain.Models.Task>> GetAllAsync()
        {
            // return await context.Tasks.Include(t => t.Users)
            //                           .ToListAsync();
            return await context.Tasks.ToListAsync();
        }

        public async Task<Domain.Models.Task> GetByIdAsync(int id)
        {
            return await context.Tasks.FirstOrDefaultAsync(t => t.TaskId == id);
        }

        public void Update(Domain.Models.Task task)
        {
            context.Tasks.Update(task);
        }
    }
}