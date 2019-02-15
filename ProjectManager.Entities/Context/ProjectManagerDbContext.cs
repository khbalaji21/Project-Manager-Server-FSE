using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using ProjectManager.Entities.DataModels;


namespace ProjectManager.Entities.Context
{
    public class ProjectManagerDbContext : DbContext
    {
        public ProjectManagerDbContext() :
          base("name=ProjectEntities")
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                        .HasRequired(p => p.Project)
                        .WithMany(t => t.tasks)
                        .HasForeignKey(p => p.Project_Id);
        }
    }
}
