﻿using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class TeamMember
    {
        public int IdTeamMember { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

    }
}
