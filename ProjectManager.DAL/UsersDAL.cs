using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Http;
using ProjectManager.Entities.Context;
using ProjectManager.Entities.DataModels;

namespace ProjectManager.DAL
{
    public class UsersDAL
    {
        private ProjectManagerDbContext db = new ProjectManagerDbContext();

        //GET: api/Users
        //public IQueryable<Users> GetUsers()
        //{
        //    return db.Users;
        //}
        public List<Users> GetUsers()
        {
            return db.Users.ToList();
        }

        // GET: api/Users/5
        //[ResponseType(typeof(Users))]
        //public async Task<IHttpActionResult> GetUser(int id)
        //{
        //    Users users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(users);
        //}
        public Users GetUser(int Id)
        {
            //return db.Users.Where(ob => ob.Id == Id).ToList();
            Users users = db.Users.Find(Id);
            return users;
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
        public bool update(Users users)
        {
            var existingUser = db.Users.Where(u => u.Id == users.Id).FirstOrDefault<Users>();
            if (existingUser != null)
            {
                existingUser.First_Name = users.First_Name;
                existingUser.Last_Name = users.Last_Name;
                db.SaveChanges();
            }
            else
                return false;

            return true;
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
        public bool create(Users user)
        {
            db.Users.Add(new Users()
            {
                First_Name = user.First_Name,
                Last_Name = user.Last_Name
            });
            db.SaveChanges();
            return true;
        }
    }
}

