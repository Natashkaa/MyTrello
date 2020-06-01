using System;

namespace MyTrello.Resources
{
    public class SaveTaskResource
    {
        public string Task_Priority { get; set; }
        public string Task_Name { get; set; }
        public string Task_CreateDate { get; set; }
        public string Task_Description { get; set; }
        public int? UserId { get; set; }
        public bool? IsArchived { get; set; }
    }
}