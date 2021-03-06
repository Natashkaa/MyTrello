using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTrello.Domain.Models
{
    public partial class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string User_FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string User_LastName { get; set; }
        [Required]
        [StringLength(150)]
        public string User_PhotoPath { get; set; }
        [Required]
        [StringLength(100)]
        public string User_Email { get; set; }
        [Required]
        [StringLength(20)]
        public string User_Password { get; set; }
        [NotMapped]
        public virtual ICollection<Task> Tasks { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}