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
        public System.Threading.Tasks.Task AddAsync(Domain.Models.Task newTask)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Domain.Models.Task task)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Domain.Models.Task>> GetAllAsync()
        {
            return await context.Tasks.Include(t => t.Users)
                                      .ToListAsync();
        }

        public Task<Domain.Models.Task> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Domain.Models.Task task)
        {
            throw new System.NotImplementedException();
        }
    }
}