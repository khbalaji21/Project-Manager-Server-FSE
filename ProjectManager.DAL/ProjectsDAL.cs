using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Http;
using ProjectManager.Entities.Context;
using ProjectManager.Entities.DataModels;

namespace ProjectManager.DAL
{
    public class ProjectsDAL
    {
        private ProjectManagerDbContext db = new ProjectManagerDbContext();

        public List<Projects> GetProjects()
        {
            return db.Projects.ToList();
        }

        public Projects GetProject(int Id)
        {
            Projects projects = db.Projects.Find(Id);
            return projects;
        }

        public bool update(Projects projects)
        {
            var existingProject = db.Projects.Where(u => u.Id == projects.Id).FirstOrDefault<Projects>();
            if (existingProject != null)
            {
                existingProject.Name = projects.Name;
                existingProject.Start_Date = projects.Start_Date;
                existingProject.End_Date = projects.End_Date;
                existingProject.Priority = projects.Priority;
                existingProject.Manager_Id = projects.Manager_Id;
                existingProject.status = projects.status;
                db.SaveChanges();
            }
            else
                return false;

            return true;
        }

        public bool create(Projects project)
        {
            db.Projects.Add(new Projects()
            {
                Name = project.Name,
                Start_Date = project.Start_Date,
                End_Date = project.End_Date,
                Priority = project.Priority,
                Manager_Id = project.Manager_Id,
                status = false
            });
            db.SaveChanges();
            return true;
        }
    }
}
