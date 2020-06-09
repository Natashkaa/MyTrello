using System.Collections.Generic;
using MyTrello.Domain.Models;
using MyTrello.Domain.Services.Communication;

namespace MyTrello.Domain.Services
{
    public interface ITaskService
    {
         System.Threading.Tasks.Task<IEnumerable<Task>> GetAllAsync();
         System.Threading.Tasks.Task<IEnumerable<Task>> GetUsersTasksAsync(int id);
         System.Threading.Tasks.Task<TaskResponse> AddAsync(Task task);
         System.Threading.Tasks.Task<TaskResponse> UpdateAsync(int id, Task task);
         System.Threading.Tasks.Task<TaskResponse> DeleteAsync(int id);
         System.Threading.Tasks.Task<TaskResponse> GetByIdAsync(int id);
    }
}