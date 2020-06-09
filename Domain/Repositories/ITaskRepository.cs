using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrello.Domain.Repositories
{
    public interface ITaskRepository
    {
         Task<IEnumerable<MyTrello.Domain.Models.Task>> GetAllAsync();
         Task<IEnumerable<MyTrello.Domain.Models.Task>> GetUsersTasksAsync(int id);
         Task<MyTrello.Domain.Models.Task> GetByIdAsync(int id);
         Task AddAsync(MyTrello.Domain.Models.Task newTask);
         void Update(MyTrello.Domain.Models.Task task);
         void Delete(MyTrello.Domain.Models.Task task);
    }
}