using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrello.Domain.Repositories;
using MyTrello.Domain.Services;
using MyTrello.Domain.Services.Communication;

namespace MyTrello.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IUnitOfWork unitOfWork;
        public TaskService( ITaskRepository taskRepository,
                            IUnitOfWork unitOfWork)
        {
            this.taskRepository = taskRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<TaskResponse> AddAsync(Domain.Models.Task task)
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskResponse> DeleteRemove(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Domain.Models.Task>> GetAllAsync()
        {
            return await taskRepository.GetAllAsync();
        }

        public Task<TaskResponse> UpdateAsync(int id, Domain.Models.Task task)
        {
            throw new System.NotImplementedException();
        }
    }
}