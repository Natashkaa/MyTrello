using MyTrello.Domain.Models;

namespace MyTrello.Domain.Services.Communication
{
    public class TaskResponse : BaseResponse
    {
        public Task Task { get; private set; }
        public TaskResponse(bool success, string message,Task task) : base(success, message)
        {
            this.Task = task;
        }

        public TaskResponse(Task task) : this(true, string.Empty, task){}
        public TaskResponse(string message) : this(false, message, null){}
    }
}