using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectManager.DAL;
using ProjectManager.Entities.DataModels;

namespace ProjectManager.BAL
{
    public class ProjectsBAL
    {
        ProjectsDAL dal = new ProjectsDAL();

        public List<Projects> getProjectsBAL()
        {
            return dal.GetProjects();
        }

        public Projects getProjectBAL(int Id)
        {
            return dal.GetProject(Id);
        }

        public bool updateProjectBAL(Projects projects)
        {
            return dal.update(projects);
        }

        public bool createProjectBAL(Projects projects)
        {
            return dal.create(projects);
        }
    }
}
