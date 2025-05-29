 using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TaskApp.Models
{
    public class TaskList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public  string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Priority { get; set; }
        public bool isCompleted { get; set; }


       
    }
}
