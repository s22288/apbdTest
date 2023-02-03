using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Project
    {
        public int IdTeam { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

    }
}
