using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectManager.Entities.Context;
using ProjectManager.Entities.DataModels;

using ProjectManager.BAL;

namespace ProjectManager.API.Controllers
{
    public class TasksController : ApiController
    {
        private ProjectManagerDbContext db = new ProjectManagerDbContext();
        TasksBAL tasksBAL = new TasksBAL();

        // GET: api/Tasks
        //public IQueryable<Tasks> GetTasks()
        //{
        //    return db.Tasks;
        //}
        public IEnumerable<Tasks> GetTasks()
        {
            //return db.Tasks;
            return tasksBAL.getTasksBAL();
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
            //return db.Tasks.Where(ob => ob.Id == Id).ToList();
            return tasksBAL.getTaskBAL(Id);
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
        public IHttpActionResult PutTasks(Tasks task)
        {
            //var existingTask = db.Tasks.Where(t => t.Id == task.Id).FirstOrDefault<Tasks>();
            //if (existingTask != null)
            //{
            //    existingTask.Name = task.Name;
            //    existingTask.Parent_Task = task.Parent_Task;
            //    existingTask.Priority = task.Priority;
            //    existingTask.User = task.User;
            //    existingTask.Start_Date = task.Start_Date;
            //    existingTask.End_Date = task.End_Date;
            //    existingTask.status = task.status;
            //    db.SaveChanges();
            //}
            //else
            //    return false;

            //return true;
            if (tasksBAL.updateTaskBAL(task))
            {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                return NotFound();
            }

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
        public IHttpActionResult PostTasks(Tasks task)
        {
            //db.Tasks.Add(new Tasks()
            //{
            //    Name = task.Name,
            //    Parent_Task = task.Parent_Task,
            //    Priority = task.Priority,
            //    User = task.User,
            //    Start_Date = task.Start_Date,
            //    End_Date = task.End_Date,
            //    status = task.status
            //});
            //db.SaveChanges();
            //return true;
            if(tasksBAL.createTaskBAL(task))
            {
                return CreatedAtRoute("DefaultApi", new { Id = task.Id }, task);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Tasks))]
        public async Task<IHttpActionResult> DeleteTasks(int id)
        {
            Tasks tasks = await db.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(tasks);
            await db.SaveChangesAsync();

            return Ok(tasks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TasksExists(int id)
        {
            return db.Tasks.Count(e => e.Id == id) > 0;
        }
    }
}