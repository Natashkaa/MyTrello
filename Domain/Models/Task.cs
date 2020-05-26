using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTrello.Domain.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        [StringLength(20)]
        public string Task_Priority { get; set; }
        [Required]
        [StringLength(70)]
        public string Task_Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime Task_CreateDate { get; set; }
        [StringLength(200)]
        public string Task_Description { get; set; }
        public int? UserId { get; set; }
        public bool? IsArchived { get; set; }

        public virtual User Users { get; set; }
    }
}