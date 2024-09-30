using System.ComponentModel.DataAnnotations;

namespace PROG2BIceTask4.Models
{
    public class TaskManager
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string? Taskdetails { get; set; }
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
    }
}
