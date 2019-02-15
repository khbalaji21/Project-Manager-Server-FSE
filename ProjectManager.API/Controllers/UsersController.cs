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

using System.Web.Http.Cors;

namespace ProjectManager.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private ProjectManagerDbContext db = new ProjectManagerDbContext();
        UsersBAL usersBAL = new UsersBAL();

        // GET: api/Users
        //public IQueryable<Users> GetUsers()
        //{
            //return db.Users;

        //}
        public List<Users> GetUsers()
        {
            return usersBAL.getUsersBAL();
        }

        // GET: api/Users/5
        //[ResponseType(typeof(Users))]
        //public async Task<IHttpActionResult> GetUsers(int id)
        //{
        //    Users users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(users);
        //}

        public Users GetUsers(int Id)
        {
            return usersBAL.getUserBAL(Id);
        }

        // PUT: api/Users/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutUsers(int id, Users users)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != users.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(users).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsersExists(id))
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
        public IHttpActionResult PutUsers(int Id, Users users)
        {
            if (usersBAL.updateUserBAL(users))
            {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Users
        //[ResponseType(typeof(Users))]
        //public async Task<IHttpActionResult> PostUsers(Users users)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Users.Add(users);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = users.Id }, users);
        //}
        public IHttpActionResult PostUsers(Users users)
        {
            if(usersBAL.createUserBAL(users))
            {
                return CreatedAtRoute("DefaultApi", new { Id = users.Id }, users);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public async Task<IHttpActionResult> DeleteUsers(int id)
        {
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            await db.SaveChangesAsync();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}