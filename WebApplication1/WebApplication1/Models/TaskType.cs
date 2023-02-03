using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class TaskType
    {
        public int IdTaskType { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

    }
}
