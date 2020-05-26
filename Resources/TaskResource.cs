using MyTrello.Domain.Models;

namespace MyTrello.Resources
{
    public class TaskResource
    {
        public int TaskId { get; set; }
        public string Task_Priority { get; set; }
        public string Task_Name { get; set; }
        public string Task_CreateDate { get; set; }
        public string Task_Description { get; set; }
        public int? UserId { get; set; }
        public bool? IsArchived { get; set; }
        public User User { get; set; }
    }
}