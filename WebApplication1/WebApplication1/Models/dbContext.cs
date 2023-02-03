using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Models
{
    public class dbContext : DbContext


    {

         public DbSet<Project>  Projects{ get; set; }
        public DbSet<Task> Tasks{ get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        public dbContext()
        {
        }

        public dbContext( DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskType>(t =>
            {
                t.HasKey(ts => ts.IdTaskType);
                t.Property(ts => ts.Name).IsRequired().HasMaxLength(100);
                t.HasData(new TaskType { Name = "niewiem", IdTaskType = 1 });
            });

            modelBuilder.Entity<TeamMember>(t =>
            {
                t.HasKey(tm => tm.IdTeamMember);
                t.Property(tm => tm.FirstName).IsRequired().HasMaxLength(100);
                t.Property(tm => tm.LastName).IsRequired().HasMaxLength(100);
                t.Property(tm => tm.Email).IsRequired().HasMaxLength(100);
                t.HasData(new TeamMember { IdTeamMember = 1, FirstName = "michał", LastName = "Kowalski", Email = "niewiem@gmail.com" });
            });

            modelBuilder.Entity<Project>(p =>
            {
                p.HasKey(ps => ps.IdTeam);
                p.Property(ps => ps.Name).IsRequired().HasMaxLength(100);
                p.Property(ps => ps.Deadline).IsRequired().HasMaxLength(100);
                p.HasData(new Project { IdTeam = 1, Name = "project1", Deadline = DateTime.Now });
            });

            modelBuilder.Entity<Task>(t =>
            {
                t.HasKey(ts => ts.IdTask);
                t.Property(ts => ts.Name).IsRequired().HasMaxLength(100);
                t.Property(ts => ts.Description).IsRequired().HasMaxLength(100);
                t.Property(ts => ts.Deadline).IsRequired();

                t.HasOne(ts => ts.Project).WithMany(s => s.Tasks).HasForeignKey(sc => sc.IdTeam);
                t.HasOne(ts => ts.TaskType).WithMany(s => s.Tasks).HasForeignKey(sc => sc.IdTaskType);

                t.HasOne(ts => ts.Creator).WithMany().HasForeignKey(sc => sc.IdCreator).OnDelete(DeleteBehavior.Restrict);
                t.HasOne(ts => ts.AssignTo).WithMany().HasForeignKey(sc => sc.IdAssignedTo).OnDelete(DeleteBehavior.Restrict);
                t.HasData(new Task { IdTask = 1, Name = "zadanie1", Description = "Opis", Deadline = DateTime.Now, IdTeam = 1, IdTaskType = 1, IdAssignedTo = 1, IdCreator = 1 });
            });

        }
    }
}
