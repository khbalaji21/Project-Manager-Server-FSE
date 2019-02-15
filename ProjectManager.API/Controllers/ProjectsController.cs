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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ProjectManager.BAL;
using ProjectManager.Entities.Context;
using ProjectManager.Entities.DataModels;

namespace ProjectManager.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectsController : ApiController
    {
        private ProjectManagerDbContext db = new ProjectManagerDbContext();
        ProjectsBAL projectsBAL = new ProjectsBAL();

        // GET: api/Projects
        //public IQueryable<Projects> GetProjects()
        //{
        //    return db.Projects;
        //}
        public List<Projects> GetProjects()
        {
            return projectsBAL.getProjectsBAL();
        }

        // GET: api/Projects/5
        //[ResponseType(typeof(Projects))]
        //public async Task<IHttpActionResult> GetProjects(int id)
        //{
        //    Projects projects = await db.Projects.FindAsync(id);
        //    if (projects == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(projects);
        //}
        public Projects GetProjects(int Id)
        {
            return projectsBAL.getProjectBAL(Id);
        }

        // PUT: api/Projects/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutProjects(int id, Projects projects)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != projects.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(projects).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProjectsExists(id))
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
        public IHttpActionResult PutProjects(int Id, Projects projects)
        {
            if (!ModelState.IsValid)
                return BadRequest("Bad More changed Model");

            if (projectsBAL.updateProjectBAL(projects))
            {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                return NotFound();
            }
        }


        // POST: api/Projects
        //[ResponseType(typeof(Projects))]
        //public async Task<IHttpActionResult> PostProjects(Projects projects)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Projects.Add(projects);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = projects.Id }, projects);
        //}
        public IHttpActionResult PostProjects(Projects projects)
        {
            if (projectsBAL.createProjectBAL(projects))
            {
                return CreatedAtRoute("DefaultApi", new { Id = projects.Id }, projects);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Projects))]
        public async Task<IHttpActionResult> DeleteProjects(int id)
        {
            Projects projects = await db.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }

            db.Projects.Remove(projects);
            await db.SaveChangesAsync();

            return Ok(projects);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectsExists(int id)
        {
            return db.Projects.Count(e => e.Id == id) > 0;
        }
    }
}