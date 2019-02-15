using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectManager.DAL;
using ProjectManager.Entities.DataModels;

namespace ProjectManager.BAL
{
    public class TasksBAL
    {
        TasksDAL dal = new TasksDAL();

        public IEnumerable<Tasks> getTasksBAL()
        {
            return dal.GetTasks();
        }

        public List<Tasks> getTaskBAL(int Id)
        {
            return dal.GetTasks(Id);
        }

        public bool updateTaskBAL(Tasks task)
        {
            return dal.update(task);
        }

        public bool createTaskBAL(Tasks task)
        {
            return dal.create(task);
        }
    }
}
