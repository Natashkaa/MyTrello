using System;
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

        public async Task<TaskResponse> AddAsync(Domain.Models.Task task)
        {
            try
            {
                await taskRepository.AddAsync(task);
                await unitOfWork.CompleteAsync();
                return new TaskResponse(task);
            }
            catch(Exception ex)
            {
                return new TaskResponse($"Error: something happend while adding task: {ex.Message}");
            }
        }

        public async Task<TaskResponse> DeleteAsync(int id)
        {
            var task = await taskRepository.GetByIdAsync(id);
            if(task == null)
                return new TaskResponse($"Can not find task with id {id}");

            try
            {
                taskRepository.Delete(task);
                await unitOfWork.CompleteAsync();
                return new TaskResponse(task);
            }
            catch(Exception ex)
            {
                return new TaskResponse($"Error: something happend while deleting task: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Domain.Models.Task>> GetAllAsync()
        {
            return await taskRepository.GetAllAsync();
        }

        public async Task<TaskResponse> UpdateAsync(int id, Domain.Models.Task task)
        {
            var existTask = await taskRepository.GetByIdAsync(id);
            if(existTask == null)
                return new TaskResponse($"Can not find task with id {id}");
            existTask.Task_Priority = task.Task_Priority;
            existTask.Task_Name = task.Task_Name;
            existTask.Task_Description = task.Task_Description;
            existTask.IsArchived = task.IsArchived;
            try
            {
                taskRepository.Update(existTask);
                await unitOfWork.CompleteAsync();
                return new TaskResponse(existTask);
            }
            catch(Exception ex)
            {
                return new TaskResponse($"User update error: {ex.Message}");
            }
        }
    }
}