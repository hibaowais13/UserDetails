using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDetails.Models;
using UserDetails.Context;




namespace UserDetails.Controllers
{
    public class UsersController : ApiController
    {

        public IEnumerable<User> Get()
        {
            using ( UserDbContext userDb = new UserDbContext())
            {
                return userDb.Users.ToList();
            }
        }

        public User Get(int id)
        {
            using (UserDbContext userDb = new UserDbContext())
            {
                return userDb.Users.FirstOrDefault(e => e.Id == id);
            }
        }

        public IHttpActionResult Post(User user)
        {
            using (UserDbContext userDb = new UserDbContext())
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                userDb.Users.Add(new User()
                {

                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    Phone = user.Phone,
                    

                });
                userDb.SaveChanges();
            }

            return Ok("User added successfully");
        }


        public IHttpActionResult Put(User user, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (UserDbContext userDb = new UserDbContext())
            {
                var existinguser = userDb.Users.Where(s => s.Id == id).FirstOrDefault<User>();

                if (existinguser != null)
                {
                    existinguser.FirstName = user.FirstName;
                    existinguser.LastName = user.LastName;

                    userDb.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok("User updated successfully");
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (UserDbContext userDb = new UserDbContext())
            {
                var user = userDb.Users
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                userDb.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                userDb.SaveChanges();
            }

            return Ok("User Deleted");
        }

    }

}



