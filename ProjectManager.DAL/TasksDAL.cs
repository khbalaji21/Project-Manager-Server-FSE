using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectManager.DAL;
using ProjectManager.Entities.Context;
using ProjectManager.Entities.DataModels;

namespace ProjectManager.DAL
{
    public class TasksDAL
    {
        private ProjectManagerDbContext db = new ProjectManagerDbContext();

        // GET: api/Tasks
        //public IQueryable<Tasks> GetTasks()
        //{
        //    return db.Tasks;
        //}
        public IEnumerable<Tasks> GetTasks()
        {
            return db.Tasks;
        }

        // GET: api/Tasks/5
        //[ResponseType(typeof(Tasks))]
        //public async Task<IHttpActionResult> GetTasks(int id)
        //{
        //    Tasks tasks = await db.Tasks.FindAsync(id);
        //    if (tasks == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tasks);
        //}
        public List<Tasks> GetTasks(int Id)
        {
            return db.Tasks.Where(ob => ob.Id == Id).ToList();
        }

        // PUT: api/Tasks/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutTasks(int id, Tasks tasks)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tasks.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(tasks).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TasksExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}
        public bool update(Tasks task)
        {
            var existingTask = db.Tasks.Where(t => t.Id == task.Id).FirstOrDefault<Tasks>();
            if (existingTask != null)
            {
                existingTask.Name = task.Name;
                existingTask.Parent_Task = task.Parent_Task;
                existingTask.Priority = task.Priority;
                existingTask.User = task.User;
                existingTask.Start_Date = task.Start_Date;
                existingTask.End_Date = task.End_Date;
                existingTask.status = task.status;
                existingTask.Project_Id = task.Project_Id;
                db.SaveChanges();
            }
            else
                return false;

            return true;
        }

        // POST: api/Tasks
        //[ResponseType(typeof(Tasks))]
        //public async Task<IHttpActionResult> PostTasks(Tasks tasks)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Tasks.Add(tasks);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = tasks.Id }, tasks);
        //}
        public bool create(Tasks task)
        {
            db.Tasks.Add(new Tasks()
            {
                Name = task.Name,
                Parent_Task = task.Parent_Task,
                Priority = task.Priority,
                User = task.User,
                Start_Date = task.Start_Date,
                End_Date = task.End_Date,
                status = task.status,
                Project_Id= task.Project_Id
            });
            db.SaveChanges();
            return true;
        }
    }
}
