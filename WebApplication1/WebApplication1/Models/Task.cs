using System;

namespace WebApplication1.Models
{
    public class Task
    {
        public int IdTask { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int IdTeam { get; set; }
        public Project Project { get; set; }
        public int IdTaskType { get; set; }
        public TaskType TaskType { get; set; }
        public int IdAssignedTo { get; set; }
        public TeamMember AssignTo { get; set; }
        public int IdCreator { get; set; }
        public TeamMember Creator { get; set; }
    }
}
